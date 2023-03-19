function connectWebSocket() {

    const socket = new WebSocket('wss://ws.finnhub.io?token=cg8taf1r01qk68o7pdj0cg8taf1r01qk68o7pdjg');
    var StockSymbol = document.getElementById("StockTicker").value;
    socket.addEventListener('open', (event) => {
        console.log("Connected to the Socket Successfully")
        socket.send(JSON.stringify({ 'type': 'subscribe', 'symbol': StockSymbol }));
    });

    socket.addEventListener('close', (event) => {
        console.log("Connection close reopening in 10 seconds")
        setTimeout(connectWebSocket,10000)
    });


    window.addEventListener('unload', (event) => {
        console.log("connection closed");
        socket.close();
    });


    socket.addEventListener('message', (event) => {
        const data = JSON.parse(event.data);
        if (data.type === 'trade') {
            document.getElementById('stock-price-panel').innerText = data.data[0].p;
        }
    });
}
connectWebSocket()