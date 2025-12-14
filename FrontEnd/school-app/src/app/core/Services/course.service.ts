import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({ providedIn: 'root' })
export class CourseService {
  private apiUrl = 'https://localhost:7154/api/Courses';

  constructor(private http: HttpClient) {}

  getCourses(CourseName: string = '') {
    return this.http.get<any>(this.apiUrl, { params: { CourseName: CourseName } });
  }
  getById(id: number) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
  addCourse(course: { name: string; description: string }) {
    return this.http.post(this.apiUrl, course);
  }
  updateCourse(id: number, body: any) {
    return this.http.put(`${this.apiUrl}/${id}`, body);
  }
  deleteCourse(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
