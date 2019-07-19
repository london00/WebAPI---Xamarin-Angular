import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastrService } from "ngx-toastr";

export class AppErrorHandler implements ErrorHandler {
  private lastError: any;
  constructor(private ngZone: NgZone, @Inject(ToastrService) private toastrService: ToastrService) {

  }

  handleError(error: any): void {
    this.lastError = error;
    this.ngZone.run(
      () => {
        console.warn(this.lastError);
        if (this.lastError.error) {
          var errorDescriptions = [];
          if (Array.isArray(error.error)) {
            error.error.forEach((e) => {
              errorDescriptions.push(e.Description);
            });

            this.toastrService.warning(errorDescriptions.join("\n"), "Validation errors", { timeOut: 5000 });
          }
          else {
            this.toastrService.error(this.lastError.error.title, "Error");
          }
        }
        else {
          this.toastrService.error("An unexpected error happened", "Error");
        }
      }
    );
  }
}
