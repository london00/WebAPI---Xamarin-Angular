// NG Modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

// Third party modules
import { ToastrModule } from 'ngx-toastr'

// Components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { VehicleComponent } from "./vehicle/vehicle/vehicle.component";

// Providers
import { MakeService } from './services/makes.service';
import { FeaturesService } from './services/features.service';
import { VehicleService } from './services/vehicle.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GetAllVehiclesComponent } from './vehicle/get-all-vehicles/get-all-vehicles.component';
import { VehicleDetailsComponent } from './vehicle/vehicle-details/vehicle-details.component';
import { PhotosService } from './services/photos.service';
import { AppErrorHandler } from './app.error-handler';
import { LoginComponent } from './admin/user/login/login.component';
import { RegisterComponent } from './admin/user/register/register.component';
import { UserService } from './services/user.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VehicleComponent,
    GetAllVehiclesComponent,
    VehicleDetailsComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'login/:email', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'vehicle/new', component: VehicleComponent },
      { path: 'vehicle/:id', component: VehicleComponent },
      { path: 'vehicles', component: GetAllVehiclesComponent },
      { path: 'vehicle/details/:id', component: VehicleDetailsComponent }
    ]),
    ToastrModule.forRoot(), // https://www.npmjs.com/package/ngx-toastr
    BrowserAnimationsModule
  ],
  providers: [
    PhotosService,
    {
      provide: ErrorHandler,
      useClass: AppErrorHandler
    },
    MakeService,
    FeaturesService,
    VehicleService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
