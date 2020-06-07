import { Component, OnInit } from '@angular/core';
import { StationService } from '../services/station.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-station-details',
  templateUrl: './station-details.component.html',
  styleUrls: ['./station-details.component.css']
})
export class StationDetailsComponent implements OnInit {

  constructor(private stationService: StationService, private route: ActivatedRoute) { }
  stationId: any;
  station: any;
  saved = false;

  ngOnInit() {
    this.stationId = this.route.snapshot.paramMap.get('id');
    console.log(this.stationId);

    this.stationService.getStation(this.stationId).subscribe(res => {
      this.station = res;
      console.log(this.station);
    });

  }

  saveUserStation() {
    this.saved = true;
    this.stationService.saveUserStation(this.stationId).subscribe(res => {

    }, error => {});
  }

}
