import { Component, OnInit } from '@angular/core';
import { GolfDataService } from '../services/golf-data.service';


// Interface for representing a round of golf, måtte lage interface for å få med course tror jeg
interface Round {
    roundID: number;
    courseID: number;
    date: Date;
    score: number;
    courseName?: string; // Optional property for course name
}

@Component({
    selector: 'app-stats',
    templateUrl: './stats.component.html',
    styleUrls: ['./stats.component.scss']
})
export class StatsComponent implements OnInit {
  handicap: number = 0;
    // Array representing club data with their names and distances
    clubs: Club[] = [
        { name: 'Driver', distance: 230 },
        { name: '3 Hybrid', distance: 200 },
        { name: '5 Iron', distance: 172 },
        { name: '6 Iron', distance: 162 },
        { name: '7 Iron', distance: 151 },
        { name: '8 Iron', distance: 140 },
        { name: '9 Iron', distance: 128 },
        { name: 'P Wedge', distance: 115 },
        { name: '52 Wedge', distance: 100 },
        { name: '56 Wedge', distance: 80 },
        { name: '60 Wedge', distance: 60 },
    ];

    
    bestCourse: any = {};
  
    rounds: Round[] = [];

    constructor(private golfDataService: GolfDataService) { }

    ngOnInit(): void {
        this.fetchBestCourse(); // Fetch best course data when component initializes
        this.fetchRoundsForPlayer4(); // Fetch rounds data for player 4 when component initializes
        this.fetchHandicapForPlayer4();
    }
    
    fetchHandicapForPlayer4(): void {
      this.golfDataService.getHandicapForPlayer4().subscribe(
        handicap => {
          this.handicap = handicap;
        },
        error => {
          console.error('Failed to fetch handicap data:', error);
        }
      );
    }

    // Function to fetch data of the best course
    fetchBestCourse(): void {
        this.golfDataService.getBestCourse().subscribe(data => {
            this.bestCourse = data;
        }, error => {
            console.error('Failed to fetch best course data:', error);
        });
    }

    // Function to fetch rounds data for player 4
    fetchRoundsForPlayer4(): void {
        this.golfDataService.getRoundsForPlayer4().subscribe((data: Round[]) => {
            this.rounds = data;
            this.populateCourseNames(); // Populate course names for each round after fetching rounds data
        }, error => {
            console.error('Failed to fetch rounds data for player 4:', error);
        });
    }

    // Function to populate course names for each round
    populateCourseNames(): void {
        this.rounds.forEach(round => {
            this.golfDataService.getCourseById(round.courseID).subscribe((course: any) => {
                round.courseName = course.courseName;
            });
        });
    }
}



// Interface for representing club data
interface Club {
    name: string;
    distance: number;
}

// Notes :
// There's an interface Club to represent the structure of club data, including properties for name and distance.
// This data is not fetched from the database but provided statically for demonstration purposes, 
// showing how to implement and use static data along with dynamic data fetched from a database.
