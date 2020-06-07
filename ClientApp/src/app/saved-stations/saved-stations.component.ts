import { Component, OnInit } from '@angular/core';
import { StationService } from '../services/station.service';

@Component({
  selector: 'app-saved-stations',
  templateUrl: './saved-stations.component.html',
  styleUrls: ['./saved-stations.component.css']
})
export class SavedStationsComponent implements OnInit {

  stations: Station[];


  constructor(private stationService: StationService) { }

  ngOnInit() {
    this.stationService.getUserStations().subscribe(res => {
      this.stations = res;
    });
  }

}
