$(function() {
    console.log("Running main script...");    
    var logger = diContainer.getService(Logger);
    logger.logMessage("Test");
});
