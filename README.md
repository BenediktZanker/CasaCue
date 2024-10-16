# CasaCue: Restaurant Waitlist App

## Summary

CasaCue is an application for managing waitlists in restaurants. The app allows guests to register online or on-site at the restaurant when it is fully booked. Guests receive notifications when their table is ready, and they can check their position in the queue at any time, as well as the estimated waiting time. This solution aims to enhance the customer experience and improve restaurant operations.

From a technical standpoint, CasaCue leverages **C#**, **Blazor** for the frontend, and **ASP.NET Core** for the backend. The app is deployed on a cloud platform, ensuring scalability, real-time data processing, and flexible data management.

## Problem Statement

During peak times, many restaurants are fully booked, and guests often face long wait times without any idea of when a table will become available. This can lead to dissatisfaction and inefficient use of time. With CasaCue, guests can spontaneously register online or on-site for a virtual waiting list. They can monitor their position in the queue and view the estimated waiting time, allowing them to use their waiting time more effectively, such as shopping nearby. Guests will receive a notification once they are next in line.

### Why the Cloud is Essential for CasaCue

This problem is particularly suited to a **cloud-based solution** for several reasons:

- **Scalability**: Restaurants across different locations can manage their waitlists simultaneously without performance issues, thanks to the cloud's ability to scale dynamically.
- **Distributed Access**: Guests and restaurant managers can access the app from different locations, making centralized cloud storage critical for real-time data updates.
- **Business Analytics**: Restaurants can use cloud-based data processing to analyze customer trends, optimize staffing, and improve overall efficiency.

CasaCue solves a common issue in restaurant management: inefficient handling of waitlists. By providing transparency and real-time updates, it improves both customer satisfaction and restaurant efficiency.

## Project Goal

The goal of CasaCue is to digitize the waitlist management for restaurants, providing two registration methods:

- **On-Site Registration**: Guests visiting the restaurant can join the waitlist on demand by scanning a QR code.
- **Online Registration**: Guests can check from home or while on the move whether the restaurant is fully booked and directly join the waitlist online.

By offering both registration methods, CasaCue ensures that the solution is flexible and scalable, catering to both in-person and remote users.

## User Stories

1. **Guest**:
   - As a guest, I want to join the waitlist either online or on-site to minimize my waiting time and receive a notification when my table is ready.
   - As a guest, I want to see my position in the queue and the estimated waiting time in real-time, so I can plan my time accordingly.
   
2. **Restaurant Manager**:
   - As a restaurant manager, I want a real-time overview of the current waitlist so I can allocate tables efficiently.
   - As a restaurant manager, I want to have access to analytics and statistics about customer wait times and peak periods to optimize staff and table management.

## Minimum Viable Product (MVP)

The **MVP** for CasaCue is to provide the core functionality that allows guests to register for the waitlist and receive notifications when their table is ready. Restaurant managers will have the ability to view and manage the waitlist in real-time.

## Benefits for Restaurant Owners and Guests

- **Transparency**: Guests always know how many people are ahead of them in line.
- **Notifications**: Guests receive alerts when their table is ready, making waiting times more comfortable.
- **Efficiency**: Restaurant managers can clearly see the current waiting situation and optimize table allocation.
- **Data-Driven Decisions**: Restaurant owners can review waitlist data, peak times, and customer flow to optimize staffing and table turnover rates.

## Technologies

The project will be implemented using the following technologies:

- **Programming Language**: C#
- **Frontend**: Blazor
- **Backend**: ASP.NET Core
- **Database**: Cloud-based storage
- **Cloud Hosting**: Cloud deployment to enable flexible scaling, real-time updates, and 24/7 availability

## Cloud Hosting and Cloud Computing

Cloud hosting and cloud computing play an essential role in CasaCue's implementation. CasaCue is more than just a local application—its reliance on the cloud brings scalability, reliability, and real-time capabilities that a local solution would not provide. Here’s how the cloud supports and enhances CasaCue:

- **Scalability**: The cloud allows CasaCue to handle fluctuating demand, ensuring smooth performance whether one or hundreds of restaurants are using the app. The infrastructure dynamically adjusts resources, keeping performance optimized without unnecessary cost.

- **Real-Time Notifications**: Guest information is processed and stored in the cloud instantly. When a table becomes available, real-time notifications are sent via email or SMS, ensuring timely updates to users.

- **Centralized Data Management**: Restaurant data, including waitlist details and analytics, is stored centrally in the cloud. This enables restaurant managers to access and manage data from any location, offering greater operational flexibility.

- **Improved Data Insights**: The cloud stores and processes large amounts of data, allowing restaurants to analyze trends such as peak times and customer flow. These insights help with data-driven decisions regarding staffing and table management.

- **Security and Reliability**: Cloud providers offer encrypted storage and automatic backups, ensuring that sensitive customer data is protected. CasaCue complies with data protection regulations, and the cloud ensures continuous availability of the app.

- **API Integration**: By hosting the backend in the cloud using ASP.NET Core, CasaCue integrates seamlessly with other restaurant management systems, like POS systems. This flexibility supports future growth, allowing easy integration of third-party services via RESTful APIs.

## Cloud Milestone Goals

Cloud deployment is a core part of CasaCue's development. From the early stages, we plan to:

- Set up a **cloud environment** on a platform like **Azure** or **AWS**, where the backend and database will be hosted.
- Use **cloud services** for notification handling, ensuring guests receive timely updates about their queue status. Services like **AWS SNS** (Simple Notification Service) or **Azure Notification Hubs** will be explored.
- **Scale the database** as the number of users grows, using cloud-based solutions such as **Azure SQL** or **Amazon RDS** to dynamically manage storage needs.

## Features and Functionalities

CasaCue offers a comprehensive set of features that improve both customer satisfaction and restaurant operations:

- **Waitlist Management**: Guests can join a queue, view their position, and receive live updates about their wait time. The cloud ensures this data is always up-to-date and accessible from anywhere.
- **Notification System**: Real-time notifications via email or SMS are sent when tables become available, powered by cloud-based notification services.
- **Admin Dashboard**: A cloud-based dashboard for restaurant managers allows them to view, manage, and allocate tables in real-time, even from remote locations.
- **Analytics**: Using cloud-based data storage and processing, restaurant managers can access reports on customer flow, peak hours, and waitlist trends.

## Project Status

### Milestones

- **Milestone 1**: Initial project setup, creation of GitHub repository, basic cloud configuration for early deployment.
- **Milestone 2**: Implementation of core features: user registration and waitlist management in cloud.
- **Milestone 3**: Full integration of email/SMS notifications and cloud-based admin dashboard.
- **Milestone 4**: Final cloud deployment, testing, and performance optimization.

### Current Status

The repository has been successfully set up, with initial files such as `.gitignore`, `LICENSE`, and `documentation` added. The next step involves implementing the database structure, setting up the cloud environment, and starting with the logic for managing the waitlist in the cloud. See the [Documentation](./documentation/environment_setup.md) file for more details.

## License

This project is licensed under the **MIT License**. See the [LICENSE](./LICENSE) file for more details.
