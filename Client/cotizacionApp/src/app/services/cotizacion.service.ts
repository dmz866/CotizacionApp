import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Response } from '../classes/Response';
import { Transaccion } from './../classes/Transaccion';

const API_URL = environment.API_URL;

@Injectable({
  providedIn: 'root'
})
export class CotizacionService {

  constructor(private http: HttpClient) { }

  getCotizaciones(moneda: string) {
    return this.http.get<Response>(`${API_URL}/Cotizacion/GetCotizacion?moneda=${moneda}`);
  }

  comprar(transaccion: Transaccion) {
    //JSON.stringify()
    return this.http.post(`${API_URL}/Cotizacion/ComprarMoneda`, transaccion);
  }
}
