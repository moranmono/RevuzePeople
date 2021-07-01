import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserGroup } from './user-group.model';

@Injectable({
  providedIn: 'root'
})
export class UserGroupService {

  constructor(private http: HttpClient) { }
  getUserGroups() {
    return this.http.get<UserGroup[]>(environment.appUrl);
  }
}
