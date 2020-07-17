import { Component, OnInit } from '@angular/core';
import { CotizacionService } from 'src/app/services/cotizacion.service';
import { Cotizacion } from 'src/app/classes/Cotizacion';

@Component({
  selector: 'app-cotizaciones',
  templateUrl: './cotizaciones.component.html',
  styleUrls: ['./cotizaciones.component.css']
})
export class CotizacionesComponent implements OnInit {
  moneda: string;
  errorMessage: string;
  cotizacion: Cotizacion;

  constructor(private cotizacionService: CotizacionService) { }

  ngOnInit() {
  }

  getCotizaciones() {
    if (!this.moneda) {
      return;
    }

    this.cotizacion = null;
    this.errorMessage = null;
    this.cotizacionService.getCotizaciones(this.moneda).subscribe(result => {
      if (result.success) {
        this.cotizacion = result.data;
      }
      else {
        this.errorMessage = result.message;
      }
    });
  }
}
