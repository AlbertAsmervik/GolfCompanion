import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class GolfDataService {
  private courseApiUrl = 'http://localhost:5153/courses'; 
  private playerApiUrl = 'http://localhost:5153/players'; 
  private tournamentApiUrl = 'http://localhost:5153/Tournament';
  private RoundApiUrl = 'http://localhost:5153/Rounds';
  
 
  


  constructor(private http: HttpClient) {}

  // GET: Fetch all courses
  getAllCourses(): Observable<any[]> {
    return this.http.get<any[]>(this.courseApiUrl);
  }

  // POST: Add a new course
  addCourse(courseData: any): Observable<any> {
    return this.http.post<any>(this.courseApiUrl, courseData);
  }

  // PUT: Update an existing course
  updateCourse(courseId: number, courseData: any): Observable<any> {
    return this.http.put<any>(`${this.courseApiUrl}/${courseId}`, courseData);
  }

  // DELETE: Remove a course
  deleteCourse(courseId: number): Observable<any> {
    return this.http.delete<any>(`${this.courseApiUrl}/${courseId}`);
  }
  // GET: Return the Course where i have my current record low strokes on
  getBestCourse(): Observable<any> {
    return this.http.get<any>(`${this.courseApiUrl}/best-course`);
  }
  


//// PLAYERS ///////

     // GET: Fetch all players
    getAllPlayers(): Observable<any[]> {
      return this.http.get<any[]>(this.playerApiUrl);
    }
  
    // POST: Add a new player
    addPlayer(playerData: any): Observable<any> {
      return this.http.post<any>(this.playerApiUrl, playerData);
    }
  
    // GET: Fetch a single player by ID
    getPlayerById(playerId: number): Observable<any> {
      return this.http.get<any>(`${this.playerApiUrl}/${playerId}`);
    }
  
    // PUT: Update an existing player
    updatePlayer(playerId: number, playerData: any): Observable<any> {
      return this.http.put<any>(`${this.playerApiUrl}/${playerId}`, playerData);
    }
  
    // DELETE: Remove a player
    deletePlayer(playerId: number): Observable<any> {
      return this.http.delete<any>(`${this.playerApiUrl}/${playerId}`);
    }
      // GET: Fetch all tournaments
  getAllTournaments(): Observable<any[]> {
    return this.http.get<any[]>(this.tournamentApiUrl);
  }
   // GET: Albert's Rounds
  getRoundsForPlayer4(): Observable<any[]> {
    return this.http.get<any[]>(`${this.RoundApiUrl}/player/4`);
  }
   // GET: Fetch a single course by ID
   getCourseById(CourseId: number): Observable<any> {
    return this.http.get<any>(`${this.courseApiUrl}/${CourseId}`);
  }
  // GET: Tournament with coursename
  getAllTournamentsWithCourses(): Observable<any[]> {
    return this.http.get<any[]>(`${this.tournamentApiUrl}/WithCourses`);
  }
    // GET: Handicap for player with ID 4
    getHandicapForPlayer4(): Observable<number> {
      return this.http.get<number>(`${this.playerApiUrl}/hcp`);
    }
  
  
}

