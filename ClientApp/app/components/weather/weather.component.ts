import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'weather',
    templateUrl: './weather.component.html',
    styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
    public weather: Weather;
    private baseUrl: string;

    constructor(private _http: Http, @Inject('BASE_URL') private _baseUrl: string) {
        //http.get(baseUrl + '/api/weather/city/Bridgewater,us').subscribe(result => {
        //    this.weather = result.json();
        //});
        //this.weather = { temp: "12", summary: "Balmy", city: "New York" };
        this.baseUrl = _baseUrl;
    }

    public getWeather(city: string) {
        this._http.get(this._baseUrl + '/api/weather/city/' + city).subscribe(r => {
            this.weather = r.json();
        });
    }
    ngOnInit() {
    }
}

interface Weather {
    temp: string;
    summary: string;
    city: string;
}