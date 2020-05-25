import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

countries: Country[];
constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
}

getCountries() {
  return this.http.get<Country[]>(this.baseUrl + 'country');
}

}



