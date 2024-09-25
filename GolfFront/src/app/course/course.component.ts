import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GolfDataService } from '../services/golf-data.service'; // Import GolfDataService for making HTTP requests

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  courses: any[] = []; // Array to hold courses retrieved from the backend
  newCourse: any = { courseName: '', par: '', strokes: '' }; // Object to hold data for adding a new course
  selectedCourse: any = null; // Object to hold data for editing an existing course
  @ViewChild('courseForm') courseForm!: NgForm;
  constructor(private golfDataService: GolfDataService) {}

  ngOnInit() {
    this.getAllCourses(); // Call getAllCourses() method when the component initializes
  }

  // Method to fetch all courses from the backend
  getAllCourses() {
    this.golfDataService.getAllCourses().subscribe(
      data => this.courses = data, // Assign response data to the courses array
      error => console.error(error) // Log any errors to the console
    );
  }

  // Method to add a new course
  addCourse() {
    if (this.newCourse.courseName && this.newCourse.par && this.newCourse.strokes) {
      this.golfDataService.addCourse(this.newCourse).subscribe(
        () => {
          this.getAllCourses(); // Refresh the courses list after adding a new course
          this.newCourse = { courseName: '', par: '', strokes: '' }; // Reset the newCourse object
           // Reset form validation state
           this.courseForm.resetForm(); // Reset the form
        },
        error => console.error(error) // Log any errors to the console
      );
    }
  }

  // Method to initiate editing of a course
  editCourse(course: any) {
    this.selectedCourse = { ...course }; // Clone the course object to prevent direct modification
  }

  // Method to update an existing course
  updateCourse() {
    if (this.selectedCourse && this.selectedCourse.courseName && this.selectedCourse.par && this.selectedCourse.strokes) {
      this.golfDataService.updateCourse(this.selectedCourse.courseID, this.selectedCourse).subscribe(
        () => {
          this.getAllCourses(); // Refresh the courses list after updating a course
          this.selectedCourse = null; // Reset the selectedCourse object
          this.courseForm.resetForm(); // Reset the form
        },
        error => console.error(error) // Log any errors to the console
      );
    }
  }

  // Method to delete a course
  deleteCourse(courseId: number) {
    this.golfDataService.deleteCourse(courseId).subscribe(
      () => this.getAllCourses(), // Refresh the courses list after deleting a course
      error => console.error(error) // Log any errors to the console
    );
  }
}



