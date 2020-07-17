import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CotizacionesComponent } from './components/cotizaciones/cotizaciones.component';
import { CompraComponent } from './components/compra/compra.component';
import { HttpClientModule } from '@angular/common/http';
import { CotizacionService } from './services/cotizacion.service';
import { FormsModule } from "@angular/forms";
@NgModule({
  declarations: [
    AppComponent,
    CotizacionesComponent,
    CompraComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    CotizacionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
