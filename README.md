# CasaCue: Restaurant Waitlist App

## Summary

In this milestone, we need to demonstrate our understanding of an application that will be deployed to the cloud, as well as our knowledge of using common tools in software development, such as Git and GitHub.

CasaCue is an application for managing waitlists in restaurants. The app allows guests to register online or on-site at the restaurant when it is fully booked. Guests receive notifications when their table is ready, and they can check their position in the queue at any time, as well as the estimated waiting time. This solution aims to enhance the customer experience and improve restaurant operations.

## Problem Statement

During peak times, many restaurants are fully booked, and guests have to wait long periods without any idea of when a table will become available. With CasaCue, guests can spontaneously register online or on-site for a virtual waiting list. They can see their position in the queue and the estimated waiting time, which allows them to spend their waiting time more effectively, such as shopping nearby. They will receive a notification once they are next in line.

### Project Goal

The goal of **CasaCue** is to digitize the waitlist management for restaurants, providing two registration methods:
- **On-Site Registration**: Guests visiting the restaurant can join the waitlist on demand.
- **Online Registration**: Guests can check from home or while on the move whether the restaurant is fully booked and directly join the waitlist online.

### Benefits for Restaurant Owners and Guests

- **Transparency**: Guests always know how many people are ahead of them in line.
- **Notifications**: Guests receive alerts when their table is ready, making waiting times more comfortable.
- **Efficiency**: Restaurant managers can clearly see the current waiting situation and optimize table allocation.

## Technologies

The project will be implemented using the following technologies:

- **Programming Language**: C#
- **Frontend**: Blazor 
- **Backend**: ASP.NET Core 
- **Database**: SQLite (still subject to confirmation)
- **Cloud Hosting**: Cloud deployment to enable flexible scaling and 24/7 availability

### Cloud Hosting and Cloud Computing

Cloud hosting and cloud computing play an essential role in CasaCue's implementation, as the application is designed for scalable deployment and efficient management of customer data. Here's how cloud hosting is used:

- **Scalability**: During peak times, the number of guests and requests can significantly increase. Hosting CasaCue on a cloud platform allows the application to scale resources dynamically, ensuring smooth performance even during high demand. This elasticity allows the infrastructure to adapt based on the current load, minimizing costs while maximizing efficiency.
- **Centralized Management**: The cloud-based architecture enables all restaurant data to be stored and processed centrally. This allows restaurant managers to access the waitlist information from anywhere, enhancing operational flexibility.
- **Real-Time Communication**: Using cloud services, CasaCue can push real-time notifications to guests. When a table becomes available, the cloud server instantly notifies guests via email or SMS, ensuring a seamless and responsive user experience.
- **Data Security and Reliability**: With cloud hosting, the application benefits from enhanced security measures such as encrypted storage and secure backups, which are managed by the cloud provider. This ensures customer data, including guest contact information and reservation details, is stored securely and reliably.
- **API Integration**: The backend API for CasaCue, developed with ASP.NET Core, is deployed in the cloud, allowing restaurants to integrate this waitlist functionality with other systems they may use, such as point-of-sale (POS) systems, via RESTful APIs. This approach ensures flexibility and modularity, making it easy for future enhancements and third-party integrations.

## Features and Functionalities

- **Waitlist Management**: Users can join a queue, view their position, and stay informed about the current status, including estimated wait time.
- **Notification System**: Guests receive notifications via email or SMS when their table is ready.
- **Admin Dashboard**: A dashboard for restaurant managers to monitor waitlist status and allocate tables efficiently.

## Project Setup

### Repository Setup

To meet the requirements of this milestone, the repository contains:

1. **Project Description (`README.md`)**: A comprehensive description of the problem being solved, the basis for the solution, and references related to it.
2. **License**: A license file defining the legal terms of use for the project code.
3. **Standard Repository Files**: Files generated automatically during the repository setup, such as `.gitignore`, which is configured to exclude files unnecessary for version control, such as build outputs and temporary files.

The main project documentation (`README.md`) should be complemented by separate documents as needed and linked appropriately for each milestone. This ensures that all information is readily accessible for project evaluation.

## Project Status

### Milestones

- **Milestone 1**: Setting up the basic project structure, creating the GitHub repository, and establishing documentation (current phase).
- **Milestone 2**: Implementation of core features (user registration and waitlist management).
- **Milestone 3**: Integration of the notification system (email, SMS, and Dashboard).
- **Milestone 4**: Cloud deployment and testing.

### Current Status

The repository has been successfully set up, with initial files such as `.gitignore` and `LICENSE` added. The next step involves implementing the database structure and the initial logic for managing the waitlist.

## License

This project is licensed under the **MIT License**. See the [LICENSE](./LICENSE) file for more details.

---

Diese `README.md`-Datei deckt alle wichtigen Aspekte ab, die sowohl für die Projektentwicklung als auch für die Anforderungen des Cloud-Deployments und -Managements von CasaCue notwendig sind. Mit dieser detaillierten Beschreibung ist das Projekt klar formuliert, und die Nutzung von Cloud-Ressourcen wird nachvollziehbar erläutert.

