var diContainer = {};
$(function() {
    diContainer = new DIContainer();
});

function DIContainer() {
    var _this = this;
    this.services = {};

    this.getService = function(serviceType) {
        var service = _this.services[serviceType.name];
        return service;
    };

    this.registerService = function(serviceType, serviceImpl) {
        var serviceTypeName = String(serviceType.name);
        _this.services[serviceTypeName] = new serviceImpl();
    };    
}

