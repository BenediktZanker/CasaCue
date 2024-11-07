# CasaCue: Restaurant Waitlist App

## Summary

CasaCue is an application for managing waitlists in restaurants. The app allows guests to register online or on-site when the restaurant is fully booked. Guests receive notifications when their table is ready, and they can check their position in the queue and estimated wait time at any time. This solution aims to enhance customer experience and improve restaurant operations.

From a technical standpoint, CasaCue leverages C# for the backend with ASP.NET Core and Blazor for the frontend. The app is deployed on a cloud platform, ensuring scalability, real-time data processing, and flexible data management.

---

## Problem Statement

During peak times, many restaurants are fully booked, leading to long wait times without any indication of when a table will be available. With CasaCue, guests can register online or on-site for a virtual waiting list, monitor their position, and view the estimated wait time. This allows them to use their waiting time effectively and receive a notification once it’s their turn.

---

## Milestones and current status

### Milestone 1: Project Setup

In the first milestone, we focused on creating and setting up the **GitHub repository** to establish a solid foundation for project development. This included:
- Initial repository setup with essential files (`README.md`, `.gitignore`, `LICENSE`)
- Basic configuration for future cloud deployment.
- Documentation covering project goals, problem statement, and fundamental requirements.

For detailed information refer to the [Documentation](./hito1-environment_setup).

### Milestone 2: Continuous Integration (CI) Implementation

In the second milestone, continuous integration (CI) was implemented for CasaCue, including:
- **Testing Integration**: An xUnit test project was created to validate core logic.
- **GitHub Actions Configuration**: An automated CI workflow was set up to ensure all code changes are automatically built and tested. This CI workflow covers the backend and test projects to support reliable development.
- **Task Runner and Assertions Library**: xUnit was selected as the testing framework, and GitHub Actions as the CI tool, as these integrate well with .NET and provide easy maintenance.

For detailed information on the current status and setup, refer to the [Documentation](./hito2-continuous_integration.md).

---

## Project Goal

The goal of CasaCue is to digitize the waitlist management for restaurants, providing two registration methods:
- **On-Site Registration**: Guests can join the waitlist by scanning a QR code at the restaurant.
- **Online Registration**: Guests can check availability remotely and join the waitlist online.

By offering these flexible registration methods, CasaCue ensures a scalable solution for both in-person and remote users.

---

## User Stories

**Guest**:
- As a guest, I want to join the waitlist either online or on-site to minimize my waiting time and receive a notification when my table is ready.
- As a guest, I want to see my position in the queue and the estimated waiting time in real-time, so I can plan my time accordingly.

**Restaurant Manager**:
- As a restaurant manager, I want a real-time overview of the current waitlist so I can allocate tables efficiently.
- As a restaurant manager, I want access to analytics on customer wait times and peak periods to optimize staff and table management.

---

## Minimum Viable Product (MVP)

The MVP for CasaCue includes:
- Simple waitlist registration for guests.
- Real-time notifications when tables are available.
- Real-time waitlist management for restaurant managers.

---

## Benefits for Restaurant Owners and Guests

- **Transparency**: Guests always know how many people are ahead in the queue.
- **Notifications**: Guests are informed as soon as their table is ready, making wait times more comfortable.
- **Efficiency**: Managers have a clear view of the waitlist status and can optimize table allocation.
- **Data-Driven Decisions**: Restaurant owners can analyze waitlist data and peak times to optimize staffing and table turnover.

---

## Technologies

- **Programming Language**: C#
- **Frontend**: Blazor
- **Backend**: ASP.NET Core
- **Database**: Cloud-based storage
- **Cloud Hosting**: Enables flexible scaling, real-time updates, and 24/7 availability

---

## License

This project is licensed under the MIT License. See the [LICENCE](./LICENSE) file for more details.