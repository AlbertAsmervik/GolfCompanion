import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GolfDataService } from '../services/golf-data.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {
  // Array to store player data retrieved from the server
  players: any[] = [];
  newPlayer: any = { firstName: '', lastName: '', handicap: '' };
  selectedPlayer: any = null;
  sortAscending = true;
  @ViewChild('playerForm') playerForm!: NgForm; // Access form using ViewChild

  constructor(private golfDataService: GolfDataService) {}

  ngOnInit() {
    // Fetch all players when the component initializes
    this.getAllPlayers();
  }

  // Toggles the sorting order of players between ascending and descending based on handicap
  toggleSortOrder() {
    this.sortAscending = !this.sortAscending;
    this.sortPlayers();
  }

  // Sorts the players array based on handicap either in ascending or descending order
  sortPlayers() {
    this.players.sort((a, b) => this.sortAscending ? a.handicap - b.handicap : b.handicap - a.handicap);
  }

  // Fetches all players from the server and sorts them based on handicap in ascending order
  getAllPlayers() {
    this.golfDataService.getAllPlayers().subscribe(
      data => {
        // Sort players based on handicap in ascending order
        this.players = data.sort((a, b) => a.handicap - b.handicap);
        this.playerForm.resetForm(); // for refresing, and not showing required
      },
      error => console.error(error)
    );
  }

  // Adds a new player to the server, updates the players list, and resets the newPlayer object
  addPlayer() {
    this.golfDataService.addPlayer(this.newPlayer).subscribe(
      player => {
        // Push the newly added player to the players array
        this.players.push(player);
        // Reset newPlayer object
        this.newPlayer = { firstName: '', lastName: '', handicap: '' };
        this.playerForm.resetForm(); // for refresing, and not showing required
      },
      error => console.error(error)
    );
  }

  // Sets the selectedPlayer property to the player being edited
  editPlayer(player: any) {
    this.selectedPlayer = { ...player };
  }

  // Updates the selected player on the server, refreshes the players list, and deselects the selected player after successful update
  updatePlayer() {
    this.golfDataService.updatePlayer(this.selectedPlayer.playerID, this.selectedPlayer).subscribe(
      () => {
        // Refresh the players list
        this.getAllPlayers();
        // Deselect player after successful update
        this.selectedPlayer = null;
        this.playerForm.resetForm();
      },
      error => console.error(error)
    );
  }

  // Deletes a player from the server and removes it from the players array
  deletePlayer(playerId: number) {
    this.golfDataService.deletePlayer(playerId).subscribe(
      () => {
        // Remove the player from the players array
        this.players = this.players.filter(player => player.playerID !== playerId);
      },
      error => console.error(error)
    );
  }
}

