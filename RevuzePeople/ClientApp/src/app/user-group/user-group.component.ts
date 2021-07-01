import { Component, OnInit } from '@angular/core';
import { UserGroup } from '../shared/user-group.model';
import { UserGroupService } from '../shared/user-group.service';

@Component({
  selector: 'app-user-group',
  templateUrl: './user-group.component.html',
  styleUrls: ['./user-group.component.css']
})
export class UserGroupComponent implements OnInit {
  userGroups: UserGroup[];
  constructor(private userGroupService: UserGroupService) { }

  ngOnInit() {
    this.userGroupService.getUserGroups()
      .subscribe(
        (res) => {
          if (res) {
            this.userGroups = res;
          }
          console.log('res', this.userGroups);
        });
  }

}
