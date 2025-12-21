import { Injectable } from '@angular/core';
import { HttpClient,HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  private apiUrl = 'https://localhost:7154/api/Students';
  private apienrollmentsUrl = 'https://localhost:7154/api/Students/MyEnrollments';
  constructor(private http: HttpClient) {}

    getStudents(page: number, pageSize: number, name?: string, className?: string): Observable<any> {
    let params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);

    if (name) params = params.set('Name', name);
    if (className) params = params.set('className', className);

    return this.http.get(this.apiUrl, { params });
  }

  getStudent(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createStudent(name:string, email:string, classId:number): Observable<any> {
    return this.http.post<any>(this.apiUrl,{ name, email, classId } );
  }
   getClasses() {
  return this.http.get<any>('https://localhost:7154/api/Classes');
}


  updateStudent(id: number, data: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, data);
  }

  deleteStudent(id: number): Observable<any> {

    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }


  getStudentEnrollments() {
    return this.http.get<any>(`${this.apienrollmentsUrl}`);
  }
}
