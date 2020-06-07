import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StationService {

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

getStations() {
  return this.http.get<Station[]>(this.baseUrl + 'stations');
}

}
