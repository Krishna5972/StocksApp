const socket = new WebSocket('wss://ws.finnhub.io?token=cg8taf1r01qk68o7pdj0cg8taf1r01qk68o7pdjg');
var StockSymbol = document.getElementById("StockTicker").value;
socket.addEventListener('open', (event) => {
    socket.send(JSON.stringify({ 'type': 'subscribe', 'symbol': StockSymbol }));
});

socket.addEventListener('message', (event) => {
    const data = JSON.parse(event.data);
    if (data.type === 'trade') {
        document.getElementById('stock-price-panel').innerText = data.data[0].p;
    }
});