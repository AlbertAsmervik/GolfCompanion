import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../services/weather.service'; 
import { GolfDataService } from '../services/golf-data.service'; 
import { CommonModule } from '@angular/common'; 
import { RouterModule } from '@angular/router'; 
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule], 
})
export class HomeComponent implements OnInit {
  weatherData: any; // Variable to store weather data
  locationQuery: string = ''; // Variable to store the location query for weather data
  tournaments: any[] = []; // Variable to store tournaments data

  constructor(private weatherService: WeatherService, private golfDataService: GolfDataService) { }

  ngOnInit(): void {
    this.loadWeather('Horten');
    this.loadTournaments();
  }

  // Method to load weather data for a specific location
  loadWeather(location: string): void {
    this.weatherService.getWeatherForCourse(location).subscribe(
      data => {
        this.weatherData = data; // Assign fetched weather data to weatherData variable
      },
      error => {
        console.error('There was an error retrieving the weather data', error); // Log error if fetching weather data fails
      }
    );
  }

  // Method to load tournaments data
  loadTournaments(): void {
    this.golfDataService.getAllTournamentsWithCourses().subscribe(
      data => {
        this.tournaments = data; // Assign fetched tournaments data to tournaments variable
      },
      error => {
        console.error('There was an error retrieving the tournaments with course data', error); // Log error if fetching tournaments data fails
      }
    );
  }
}

