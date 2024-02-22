const {createProxyMiddleware} = require("http-proxy-middleware");

const context = [
    "/api/user",
    "/api/login",
    "/api/task",
];

module.exports = function(app){
    const appProxy = createProxyMiddleware("/api",{
        target: "https://localhost:7002",
        secure: false,
        headers: {
            Connection: "Keep-Alive"
        }
    });

    app.use(appProxy);
}