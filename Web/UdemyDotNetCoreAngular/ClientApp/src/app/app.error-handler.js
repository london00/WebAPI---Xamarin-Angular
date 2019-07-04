"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var ngx_toastr_1 = require("ngx-toastr");
var AppErrorHandler = /** @class */ (function () {
    function AppErrorHandler(ngZone, toastrService) {
        this.ngZone = ngZone;
        this.toastrService = toastrService;
    }
    AppErrorHandler.prototype.handleError = function (error) {
        var _this = this;
        this.lastError = error;
        this.ngZone.run(function () {
            console.warn(_this.lastError);
            if (_this.lastError.error) {
                _this.toastrService.error(_this.lastError.error.title, "Error");
            }
            else {
                _this.toastrService.error("An unexpected error happened", "Error");
            }
        });
    };
    AppErrorHandler = __decorate([
        __param(1, core_1.Inject(ngx_toastr_1.ToastrService))
    ], AppErrorHandler);
    return AppErrorHandler;
}());
exports.AppErrorHandler = AppErrorHandler;
//# sourceMappingURL=app.error-handler.js.map