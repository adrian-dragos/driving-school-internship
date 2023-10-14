import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ILesson } from "./lesson";

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {


    constructor(private http: HttpClient) { }

    getLessons() : ILesson[] {
      return [
        {
            "date": new Date(2022, 0, 14, 15, 0),
            "instructor": "Dorin Soficiuc",
            "car": "Dacia Logan",
            "gearType": "mecanică",
        },
        {
            "date": new Date(2022, 0, 14, 13, 30),
            "instructor": "Dorin Soficiuc",
            "car": "Dacia Logan",
            "gearType": "mecanică"
        },
        {
            "date": new Date(2022, 0, 14, 16, 30),
            "instructor": "Dorin Soficiuc",
            "car": "Dacia Logan",
            "gearType": "mecanică"
        },
        {
            "date": new Date(2022, 0, 14, 10, 30),
            "instructor": "Dorin Soficiuc",
            "car": "Dacia Logan",
            "gearType": "mecanică"
        },
        {
            "date": new Date(2022, 1, 14, 10, 30),
            "instructor": "Daniel Ovidiu",
            "car": "Renault Zoe",
            "gearType": "automată"
        },
        {
            "date": new Date(2021, 12, 11, 10, 30),
            "instructor": "Daniel Ovidiu",
            "car": "Renault Zoe",
            "gearType": "automată"
        },
        {
            "date": new Date(2023, 1, 14, 10, 30),
            "instructor": "Daniel Ovidiu",
            "car": "Renault Zoe",
            "gearType": "automată"
        },
      ]
    }
}