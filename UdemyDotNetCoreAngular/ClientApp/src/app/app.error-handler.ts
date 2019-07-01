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
        if (this.lastError.error) {
          this.toastrService.error(this.lastError.error.title, "Error");
          console.warn(this.lastError.error);
        }
        else {
          this.toastrService.error("An unexpected error happened", "Error");
        }
      }
    );
  }
}
