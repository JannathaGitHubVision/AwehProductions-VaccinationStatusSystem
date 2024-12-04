# 🌥️ CloudDev_SecondYear

This project is part of the second-year coursework for **CLDV6212**, focused on developing cloud-based solutions for **Aweh Productions**, a South African entrepreneurial company specializing in smaller musical events. The project involves creating a secure, scalable system for vaccination status checks at event entrances.

## 📚 Project Overview

The project is divided into three parts, each building upon the previous one to create a comprehensive solution that meets the requirements of Aweh Productions.

### 🏢 Background

Aweh Productions requires a secure method to verify vaccination statuses at event entrances. The solution must:
- ⏱️ Retrieve vaccination information in seconds.
- 📊 Store various data formats from different vaccination providers.
- 💰 Maintain low operational costs.

### 🔍 Part 1: Azure Function with HTTP Trigger

In Part 1, I focused on understanding the differences between on-premises and cloud solutions. I conducted research and created a table comparing these two approaches, providing definitions and examples for each.

#### Key Activities:
- **Research and Comparison**: Created a table comparing on-premises vs. cloud solutions.
- **Azure Function Deployment**: Developed an Azure Function that is triggered by an HTTP request. The function queries vaccination status based on a South African ID or passport number.
  - The URL format is: `http://<APP_NAME>.azurewebsites.net/api/id/xxxxxxxxxxxxx`
  - Hardcoded valid ID numbers return dummy vaccination data.
- **Documentation**: Compiled screenshots of the function code, its execution in a web browser, and the deployment steps in a Microsoft Word document.

### 🔄 Part 2: Queue Storage and Azure Function with Queue Trigger

In Part 2, I expanded the functionality of the Azure Function by integrating Azure Queue Storage.

#### Key Activities:
- **.NET Core Console Application**: Developed a console application that allows messages to be added to a data storage queue. The application creates the queue if it does not exist and inserts messages in various formats.
- **Function Modification**: Changed the Azure Function from an HTTP trigger to a Queue trigger. Now, when a message is placed in the queue, the function retrieves the message and inserts its contents into an Azure SQL Database table.
- **Deployment**: All components were deployed to Azure and tested to ensure functionality.

### ⚙️ Part 3: Enhancements and Final Implementation

In Part 3, I focused on optimizing the solution to meet Aweh Productions' primary requirements.

#### Key Activities:
- **Azure Components Listing**: Compiled a list of Azure components used throughout the project, detailing their technology choices and hosting models.
- **Motivation for Changes**: Analyzed the initial components and motivated necessary changes to meet the performance and cost requirements.
- **Function Improvements**: Implemented changes to the Azure Function from Part 2 to enhance performance and accommodate different data formats.
- **Testing**: Conducted tests using the console application to ensure the final solution works as intended, providing screenshots of the application running with various message formats.

## 🎯 Conclusion

This project demonstrates the ability to design and implement a cloud-based solution that meets specific business requirements. The progressive development through Parts 1, 2, and 3 showcases the integration of various Azure services and the importance of optimizing cloud solutions for performance and cost-effectiveness.

## 📋 Requirements

- Access to an Azure account with available credit.
- Microsoft Visual Studio for coding.
- Submission of each part as a single Microsoft Word document.

## 📸 Screenshots and Documentation

All relevant screenshots, code snippets, and deployment steps are included in the Microsoft Word documents submitted for each part of the project.
