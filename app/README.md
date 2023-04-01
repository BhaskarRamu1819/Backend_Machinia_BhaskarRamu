# Backend_Machinia_Bhaskar
***
## Index

1. [Post addnewcenter](#post-Add-New-Traing-Centers)

2. [Get trainingcenters](#get-trainingcenters)

    - [Get unique centers data](#Unique-CenterCode-Data-API)


***

[//]: # (1. [API Reference]&#40;#api-reference&#41;)

[//]: # (2. [In UI]&#40;#in-ui&#41;)

[//]: # (3. [TBD]&#40;#tbd&#41;)


## API Reference

#### Post Add New Traing Centers

>POST
> /addnewcenter

Query parameters 

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `method` | `string` | **Required**.               |

Request body 

new data entry

```json
{
    "CenterName": "Jagruthi Ocational Training Center",
    "CenterCode": "HYDUPPB77195",
    "Address": {
                "DetailedAddress": "2nd Floor, Bibisayab Maqta",
                "City": "Uppal",
                "State": "Telangana",
                "Pincode": "500039"
                },
    "StudentCapacity": 6000 ,
    "CoursesOffered": ["MBBS", "BDS", "BAMS", "BHMS"],
    "ContactEmail": "jagruthi.nlg@gmail.com",
    "ContactPhone": "9355350397"
}
```



Query_parameter- Input_body



1. If CenterName graterthan 40 chracters error message returned**.<br>
2. If CenterCode length is equal to 12 characters or not, then returns error message<br>
3. when new data inserting, CreatedOn key assigned an epoch time. If any user entries are there discarded <br>
4. Email and phone number validated proper formate **{"key":value}**.<br>
5. Address saved as an object formate and its inner detailed keys are (DetailedAddress, City, State, Pincode)


#### Get trainingcenters


>  GET /trainingcenters

Query api 

| API               | sub_query| Description                |
| :--------         | :------- | :------------------------- |
| `trainingcenters` | `string` | **Optional**.              |

Response 

```json
[
    {
        "centerName": "Haryana Education society",
        "centerCode": "HARROTK80990",
        "createdOn": 1680263445,
        "studentCapacity": 8000,
        "address": {
            "DetailedAddress": "VPO-KILOI",
            "City": "Rohtak",
            "State": "Haryana",
            "Pincode": "124001"
        },
        "coursesOffered": [
            "Diploma Engg",
            "Diploma Pharmacy",
            "B.Pharmacy",
            "B.E./B.Tech"
        ],
        "contactEmail": "virendersharma426@gmail.com",
        "contactPhone": "9355350397"
    },
    {
        "centerName": "Jagruthi Ocational Training Center",
        "centerCode": "HYDUPPB77190",
        "createdOn": 1680275006,
        "studentCapacity": 6000,
        "address": {
            "DetailedAddress": "2nd Floor, Bibisayab Maqta",
            "City": "Uppal",
            "State": "Telangana",
            "Pincode": "500039"
        },
        "coursesOffered": [
            "MBBS",
            "BDS",
            "BAMS",
            "BHMS"
        ],
        "contactEmail": "jagruthi.nlg@gmail.com",
        "contactPhone": "8885848436"
    },
    {
        "centerName": "Jagruthi Ocational Training Center",
        "centerCode": "HYDUPPB77195",
        "createdOn": 1680290598,
        "studentCapacity": 6000,
        "address": {
            "DetailedAddress": "2nd Floor, Bibisayab Maqta",
            "City": "Uppal",
            "State": "Telangana",
            "Pincode": "500039"
        },
        "coursesOffered": [
            "MBBS",
            "BDS",
            "BAMS",
            "BHMS"
        ],
        "contactEmail": "jagruthi.nlg@gmail.com",
        "contactPhone": "9355350397"
    }
]
```

- returned all the saved training centers data


#### Unique CenterCode Data API

>  GET 
> /trainingcenters/HYDUPPB77195

Query api 

| API               | sub_query    | Description                |
| :--------         | :-------     | :------------------------- |
| `trainingcenters` | HYDUPPB77195 | **Optional**.              |

Response 

```json
    {
        "centerName": "Jagruthi Ocational Training Center",
        "centerCode": "HYDUPPB77195",
        "createdOn": 1680290598,
        "studentCapacity": 6000,
        "address": {
            "DetailedAddress": "2nd Floor, Bibisayab Maqta",
            "City": "Uppal",
            "State": "Telangana",
            "Pincode": "500039"
        },
        "coursesOffered": [
            "MBBS",
            "BDS",
            "BAMS",
            "BHMS"
        ],
        "contactEmail": "jagruthi.nlg@gmail.com",
        "contactPhone": "9355350397"
    }

```

```

*** 

- returns user selection center code data only
- 



[//]: # (## TBD)

[//]: # ()
[//]: # (1&#41; On click, option for edit will be shown,)

[//]: # (2&#41; training centers pop-up flow)

**[⬆ Back to Top](#Backend-Machinia-Bhaskar)**


