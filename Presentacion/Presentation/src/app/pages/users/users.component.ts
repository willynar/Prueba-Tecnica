import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { CUser } from 'src/app/classes/cuser';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public headers: HttpHeaders;
  public listUsers:CUser[];
  constructor(
    public http: HttpClient
  ) {
    this.headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "POST: GET: OPTIONS: PUT",
      Authorization: "Bearer ",
    });
    this.listUsers=[];
  }

  ngOnInit(): void {
    // this.consultar();
  }

  public consultar() {
    this.get('https://localhost:44306/api/Usuario')
      .then((result: any) => {
        console.log(result);
        this.listUsers = [];
        this.listUsers = result;
        // this.updateTable();
      }).catch((err: any) => {
          console.log();
      });
  }

  //Ejecutar servicios verbo Get con un parametro o sin parametros
  public get(url: string, id?: string) {
    if (id === undefined) {
      id = "";
    }
    let api = '' + url + id;
    return new Promise((resolve, reject) => {
      this.http.get(api, { headers: this.headers }).subscribe(
        (res) => {
          resolve(res);
        },
        (err) => {
          reject(err);
        }
      );
    });
  }

  // const t = require('worker_threads');

  // console.log(t);
  
  // test('dummy', () => {
  //   expect(t).toBeDefined();
  // });
  
  
}
