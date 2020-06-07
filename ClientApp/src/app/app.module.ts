import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
// import ngx-translate and the http loader
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ResetPasswordConfirmationComponent } from './reset-password-confirmation/reset-password-confirmation.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { EmailConfirmationComponent } from './email-confirmation/email-confirmation.component';
import { ChangeLanguageComponent } from './change-language/change-language.component';
import { AllStationsComponent } from './all-stations/all-stations.component';
import { StationDetailsComponent } from './station-details/station-details.component';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      CounterComponent,
      FetchDataComponent,
      RegistrationComponent,
      LoginComponent,
      LoginComponent,
      UserProfileComponent,
      ResetPasswordComponent,
      ResetPasswordConfirmationComponent,
      ChangePasswordComponent,
      EmailConfirmationComponent,
      ChangeLanguageComponent,
      AllStationsComponent,
      StationDetailsComponent
   ],
   imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),



    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    HttpClientModule,
    TranslateModule.forRoot({
        loader: {
            provide: TranslateLoader,
            useFactory: HttpLoaderFactory,
            deps: [HttpClient]
        }
    }),
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path : 'registration', component: RegistrationComponent},
      { path: 'login', component: LoginComponent},
      { path: 'user-profile', component: UserProfileComponent},
      { path: 'reset-password',
        component: ResetPasswordComponent,
        children: [
          {
            path: 'confirmation',
            component: ResetPasswordConfirmationComponent
          }
        ]
      },
      { path: 'change-password', component: ChangePasswordComponent },
      { path: 'email-confirmation', component: EmailConfirmationComponent },
      { path: 'change-language', component: ChangeLanguageComponent},
      { path: 'all-stations', component: AllStationsComponent},
      { path: 'station/:id', component: StationDetailsComponent, pathMatch: 'full'}
    ]),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
