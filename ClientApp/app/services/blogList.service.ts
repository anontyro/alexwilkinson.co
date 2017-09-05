import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import 'rxjs/add/operator/map';
import { BlogPost } from '../components/blogview/bloglist/blogpost/blogpostmodel';

@Injectable()
export class BlogListService
{
    private readonly _url = "/api/BlogPosts/range/";
    private cachedBlogList = new ReplaySubject(1);
    private currentPage = 0;
    private returnLimit = 25;
    @Inject('ORIGIN_URL') originUrl: string

    constructor(
        private http: Http,

    ) { }

    public getList(forceRefresh?: boolean) {
        if (!this.cachedBlogList.observers.length || forceRefresh) {
            this.http.get(this.originUrl + this._url)
                .map(response => response.json() as BlogPost[])
                .subscribe(response => {
                    this.cachedBlogList.next(response),
                        error => {
                            this.cachedBlogList.error(error);
                            this.cachedBlogList = new ReplaySubject(1);
                        }
                });
        }
        return this.cachedBlogList;
    }


}

