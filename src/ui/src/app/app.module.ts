import { HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FileUploaderModule } from './file-uploader/modules/file-uploader/file-uploader.module';
import { LanguageSwitcherComponent } from './file-uploader/feature/language-switcher/language-switcher.component';
import { NotifierComponent } from './notifier/feature/notifier/notifier.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SpinnerComponent } from './spinner/feature/spinner/spinner.component';
import { SpinnerModule } from './spinner/modules/spinner/spinner.module';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    LanguageSwitcherComponent,
    NotifierComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FileUploaderModule,
    SpinnerModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
