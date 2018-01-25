import { Title } from '@angular/platform-browser';
import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Subscription }   from 'rxjs/Subscription';

import { DataService } from './shared/services/data.service';

/*
 * App Component
 * Top Level Component
 */

@Component({
    selector: 'test-app',
    styleUrls: ['./app.component.scss'],
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
    Authenticated: boolean = false;
    subscription: Subscription;

    constructor(private titleService: Title) {}

    ngOnInit() {
        console.log('app on init');
    }

    public setTitle(newTitle: string) {
        this.titleService.setTitle('Test Sunwing');
    }
}