import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  private baseUrl = 'http://api.weatherapi.com/v1';

  constructor(private http: HttpClient, private configService: ConfigService) {}

  getWeatherForCourse(location: string): Observable<any> {
    return this.configService.getConfig().pipe(
      switchMap(config => {
        const apiKey = config.apiKey;
        const url = `${this.baseUrl}/current.json?key=${apiKey}&q=${location}`;
        return this.http.get(url);
      })
    );
  }
}
