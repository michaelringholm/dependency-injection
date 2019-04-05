$(function() {
    console.log("Registering services");
    diContainer.registerService(Logger, LoggerMock);
    diContainer.registerService(Logger, LoggerImpl);
});



