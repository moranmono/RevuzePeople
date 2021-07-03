import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserGroup } from '../shared/user-group.model';
import { UserGroupService } from '../shared/user-group.service';

@Component({
  selector: 'app-user-group',
  templateUrl: './user-group.component.html',
  styleUrls: ['./user-group.component.css']
})
export class UserGroupComponent implements OnInit {
  private groupId: number;
  userGroup: UserGroup;
  constructor(
    private userGroupService: UserGroupService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.groupId = +this.route.snapshot.paramMap.get('groupId');
    console.log('groupId', this.groupId);
    this.userGroupService.getUserGroups()
      .subscribe(
        (res) => {
          if (res) {
            this.userGroup = res[this.groupId];
          }
        });
  }

}
