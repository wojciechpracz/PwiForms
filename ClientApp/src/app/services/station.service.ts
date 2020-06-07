import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class StationService {

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

getStations() {
  return this.http.get<Station[]>(this.baseUrl + 'stations');
}

getStation(id) {
  return this.http.get<any>(this.baseUrl + 'stations/' + id);
}

saveUserStation(stationId: number) {
  const jsonObj: any = JSON.parse(localStorage.getItem('currentUser'));
  const currentUser = <User>jsonObj;

  const stationUser = {
    'stationId': Number(stationId),
    'userId': currentUser.id
  };

  return this.http.post(this.baseUrl + 'stations', stationUser);
}

getUserStations() {
  const jsonObj: any = JSON.parse(localStorage.getItem('currentUser'));
  const currentUser = <User>jsonObj;
  return this.http.get<Station[]>(this.baseUrl + 'stations/userStations/' + currentUser.id);

}

}
