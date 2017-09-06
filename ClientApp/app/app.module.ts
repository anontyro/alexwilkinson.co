import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavBarComponent } from './components/navbar/navbar.component';
import { AboutviewComponent } from './components/aboutview/aboutview.component';
import { BlogviewComponent } from './components/blogview/index';
import { BlogListComponent } from './components/blogview/index';
import { BlogPostComponent } from './components/blogview/index';

import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
import { ServerModule } from '@angular/platform-server';

import { BlogListService } from './services/index';



export const appRoutes: Routes = [
    //detail-view will be used for new, update and edit
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'blog', component: BlogviewComponent },
    { path: 'about', component: AboutviewComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        FooterComponent,
        HomeComponent,
        NavBarComponent,
        BlogviewComponent,
        BlogListComponent,
        BlogPostComponent,
        AboutviewComponent,
    ],
    imports: [
        ServerModule,
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot(appRoutes, { enableTracing: false })
    ],
    providers: [
        BlogListService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
        
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }