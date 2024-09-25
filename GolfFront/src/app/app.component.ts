import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root', // Selector for AppComponent
  templateUrl: './app.component.html', // Template URL for the component
  styleUrls: ['./app.component.scss'] // Stylesheets for the component
})
export class AppComponent implements OnInit {
  currentYear: number = new Date().getFullYear(); // Dynamic year
  golfFact: string = ""; // For displaying a random golf fact

  // Array of golf facts
  private golfFacts: string[] = [
    "The chances of making two holes-in-one in a round of golf are one in 67 million.",
    "Golf balls were originally made of wood.",
    "The longest recorded drive was over 515 yards.",
    "St. Andrews in Scotland is considered the 'home of golf'.",
  ];

  constructor() {}

  ngOnInit() {
    // Initialize the golf fact when the component initializes
    this.golfFact = this.getRandomGolfFact();
  }

  // Method to get a random golf fact from the array
  getRandomGolfFact(): string {
    return this.golfFacts[Math.floor(Math.random() * this.golfFacts.length)];
  }
}

