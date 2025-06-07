
# EmployeeApi

API สำหรับจัดการข้อมูลพนักงาน โดยใช้ ASP.NET Core Web API ตามหลัก Clean Architecture และ CQRS พร้อมเชื่อมต่อฐานข้อมูลด้วย Entity Framework Core

## 🔧 เทคโนโลยีที่ใช้

- .NET 9 / ASP.NET Core Web API
- Entity Framework Core
- MediatR (CQRS)
- AutoMapper
- Swagger (OpenAPI)
- SQL Server

## 🏗️ โครงสร้างโปรเจกต์ (Clean Architecture)

```
EmployeeApi.sln
│
├── EmployeeApi.Api                // Presentation Layer
├── EmployeeApi.Application        // Application Layer (CQRS, DTO, Interfaces)
├── EmployeeApi.Domain             // Domain Layer (Entities)
└── EmployeeApi.Infrastructure     // Infrastructure Layer (EF Core, Repository)
```

## 🚀 การเริ่มต้นใช้งาน

### 1. โคลนโปรเจกต์

```bash
git clone https://github.com/Suphakorn1999/EmployeeApi.git
cd EmployeeApi
```

### 2. ตั้งค่า Connection String

แก้ไขไฟล์ `appsettings.json` ที่ `EmployeeApi.Api/appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EmployeeDb;Trusted_Connection=True;"
}
```

### 3. สร้างฐานข้อมูลและ Migration

```bash
cd EmployeeApi.Infrastructure
dotnet ef migrations add InitialCreate --project EmployeeApi.Infrastructure --startup-project ../EmployeeApi.Api
dotnet ef database update --project EmployeeApi.Infrastructure --startup-project ../EmployeeApi.Api
```

### 4. รันโปรเจกต์

```bash
cd ../EmployeeApi.Api
dotnet run
```

เปิดเว็บเบราว์เซอร์ที่:
```
https://localhost:<port>/swagger
```

## ✅ Endpoint ตัวอย่าง

| Method | URL                   | คำอธิบาย                 |
|--------|-----------------------|---------------------------|
| GET    | /api/employees        | ดึงรายชื่อพนักงานทั้งหมด |
| GET    | /api/employees/{id}   | ดึงข้อมูลพนักงานตาม ID   |
| POST   | /api/employees        | เพิ่มข้อมูลพนักงานใหม่   |
| PUT    | /api/employees/{id}   | แก้ไขข้อมูลพนักงาน       |
| DELETE | /api/employees/{id}   | ลบพนักงานออกจากระบบ     |

## 🧪 การทดสอบผ่าน Swagger

API รองรับการทดสอบผ่าน Swagger UI ที่ URL:

```
https://localhost:<port>/swagger/index.html
```

💡 จัดทำโดย [Suphakorn1999](https://github.com/Suphakorn1999)
