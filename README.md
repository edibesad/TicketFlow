# TicketFlow

[English](#english) | [Türkçe](#türkçe)

---

## English

### 1. Overview
TicketFlow is a high-performance ticket reservation system designed to handle concurrent seat booking requests efficiently. A key feature of this project is its implementation of **Distributed Locking** using Redis to prevent race conditions during high-concurrency booking scenarios (e.g., stopping multiple users from booking the same seat simultaneously).

### 2. Key Features
- **Seat Implementation**: Capability to list all seats and view their realtime availability status.
- **Concurrency Control**: Robust handling of race conditions using Redis `LockTakeAsync` / `LockReleaseAsync`.
- **Scalable Architecture**: Built with potential for horizontal scaling, supported by Kubernetes manifests.
- **Data Persistence**: Uses **PostgreSQL** for storing seat data and booking records reliably.
- **Containerization**: Fully dockerized environment for development and deployment.

### 3. Tech Stack
- **Core Framework**: .NET (Compatible with modern .NET versions)
- **Database**: PostgreSQL (Entity Framework Core)
- **Caching & Locking**: Redis (StackExchange.Redis)
- **Deployment**: Docker & Kubernetes
- **Documentation**: Swagger UI

### 4. Getting Started

#### Prerequisites
- **.NET SDK** (Latest version recommended)
- **Docker** and **Docker Compose**

#### Installation & Running
The project uses Docker Compose to manage infrastructure dependencies (PostgreSQL & Redis).

1. **Clone the Repository**
   ```bash
   git clone https://github.com/edibesad/TicketFlow.git
   cd TicketFlow
   ```

2. **Start Infrastructure Services**
   Run the development compose file to start Redis and PostgreSQL:
   ```bash
   docker-compose -f docker-compose.dev.yml up -d
   ```

3. **Run the Application**
   Navigate to the API directory and run the application:
   ```bash
   cd src/TicketFlow.Api
   dotnet run
   ```
   *Note: The application is configured to connect to `localhost` ports for Redis (6379) and Postgres (5432) by default in Development mode.*

4. **Access the API**
   Open your browser and navigate to the Swagger UI (typically):
   `http://localhost:5000/swagger` or `http://localhost:5246/swagger` (check console output for exact port).

### 5. API Endpoints
- **GET** `/api/Booking`
  - Returns a list of all seats with their ID, Section, Number, and Availability.
- **POST** `/api/Booking/book/{seatId}`
  - Attempts to book a specific seat. Returns success message or conflict if already booked/busy.

### 6. Kubernetes Deployment
The `k8s/` directory contains manifests for deploying TicketFlow to a Kubernetes cluster.
- `deployment.yaml`: Application deployment and service definition.
- `infrastructure.yaml`: Redis and PostgreSQL stateful sets/services.
- `hpa.yaml`: Horizontal Pod Autoscaler configuration.

To deploy:
```bash
kubectl apply -f k8s/
```

---

## Türkçe

### 1. Proje Özeti (Overview)
TicketFlow, eşzamanlı koltuk rezervasyon isteklerini verimli bir şekilde yönetmek için tasarlanmış yüksek performanslı bir bilet rezervasyon sistemidir. Projenin en önemli özelliği, yoğun talep anlarında **Redis Dağıtık Kilitleme (Distributed Locking)** mekanizmasını kullanarak "Race Condition" (yarış durumu) hatalarını önlemesidir. Bu sayede aynı anda birden fazla kullanıcının aynı koltuğu rezerve etmesi engellenir.

### 2. Temel Özellikler
- **Koltuk Yönetimi**: Tüm koltukları ve anlık doluluk durumlarını listeleme yeteneği.
- **Eşzamanlılık Kontrolü (Concurrency)**: Redis `LockTakeAsync` kullanarak çifte rezervasyonları önleyen sağlam yapı.
- **Ölçeklenebilir Mimari**: Kubernetes manifestleri ile desteklenen, yatay ölçeklendirmeye uygun tasarım.
- **Veri Kalıcılığı**: Koltuk ve rezervasyon verilerini güvenli bir şekilde saklamak için **PostgreSQL** kullanımı.
- **Konteynerizasyon**: Geliştirme ve dağıtım için Docker desteği.

### 3. Teknoloji Yığını
- **Core Framework**: .NET (Modern .NET sürümleri ile uyumlu)
- **Veritabanı**: PostgreSQL (Entity Framework Core)
- **Önbellek & Kilitleme**: Redis (StackExchange.Redis)
- **Dağıtım**: Docker & Kubernetes
- **Dokümantasyon**: Swagger UI

### 4. Kurulum ve Başlangıç

#### Gereksinimler
- **.NET SDK**
- **Docker** ve **Docker Compose**

#### Kurulum Adımları
Proje, altyapı bağımlılıklarını (PostgreSQL & Redis) yönetmek için Docker Compose kullanır.

1. **Projeyi İndirin**
   ```bash
   git clone https://github.com/edibesad/TicketFlow.git
   cd TicketFlow
   ```

2. **Altyapı Servislerini Başlatın**
   Redis ve PostgreSQL'i ayağa kaldırmak için geliştirme compose dosyasını çalıştırın:
   ```bash
   docker-compose -f docker-compose.dev.yml up -d
   ```

3. **Uygulamayı Çalıştırın**
   API klasörüne gidin ve uygulamayı başlatın:
   ```bash
   cd src/TicketFlow.Api
   dotnet run
   ```
   *Not: Uygulama, Geliştirme (Development) modunda varsayılan olarak `localhost` üzerindeki Redis (6379) ve Postgres (5432) portlarına bağlanacak şekilde yapılandırılmıştır.*

4. **API'ye Erişim**
   Tarayıcınızı açın ve Swagger arayüzüne gidin (genellikle):
   `http://localhost:5000/swagger` veya `http://localhost:5246/swagger` (kesin port için terminal çıktısını kontrol edin).

### 5. API Uç Noktaları (Endpoints)
- **GET** `/api/Booking`
  - Tüm koltukları; ID, Bölüm, Numara ve Doluluk durumu ile birlikte listeler.
- **POST** `/api/Booking/book/{seatId}`
  - Belirtilen koltuğu rezerve etmeye çalışır. Başarılı olursa onay döner, koltuk doluysa veya meşgulse hata/çakışma (conflict) döner.

### 6. Kubernetes Dağıtımı
`k8s/` klasörü, TicketFlow uygulamasını bir Kubernetes kümesine dağıtmak için gerekli manifest dosyalarını içerir.
- `deployment.yaml`: Uygulama deployment ve servis tanımları.
- `infrastructure.yaml`: Redis ve PostgreSQL tanımları.
- `hpa.yaml`: Yatay Ölçeklendirme (Horizontal Pod Autoscaler) yapılandırması.

Dağıtım için:
```bash
kubectl apply -f k8s/
```
