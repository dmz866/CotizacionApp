import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompraComponent } from './components/compra/compra.component';
import { CotizacionesComponent } from './components/cotizaciones/cotizaciones.component';

const routes: Routes = [
  { path: 'cotizaciones', component: CotizacionesComponent },
  { path: 'compra', component: CompraComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
