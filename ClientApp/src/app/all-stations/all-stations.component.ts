import { Component, OnInit } from '@angular/core';
import { StationService } from '../services/station.service';

@Component({
  selector: 'app-all-stations',
  templateUrl: './all-stations.component.html',
  styleUrls: ['./all-stations.component.css']
})
export class AllStationsComponent implements OnInit {

  stations: Station[];

  constructor(private stationService: StationService) { }

  ngOnInit() {

    this.stationService.getStations().subscribe(res => {
      this.stations = res;
      console.log(this.stations[0]);
    });
  }



}
