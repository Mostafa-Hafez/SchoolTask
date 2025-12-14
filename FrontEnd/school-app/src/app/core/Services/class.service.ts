import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
  apiUrl = 'https://localhost:7154/api/Classes';

  constructor(private http: HttpClient) {}

  getClasses(page: number, pageSize: number, name: string = '') {
    return this.http.get(`${this.apiUrl}?page=${page}&pageSize=${pageSize}&ClassName=${name}`);
  }

  getClassById(id: number) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  addClass(data: any) {
    return this.http.post(this.apiUrl, data);
  }

  updateClass(id: number, data: any) {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  deleteClass(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
