<p>
  <img align="left" src="./uofr_logo.jpg" alt="U of R logo" width="39.055%"/>
  <img align="right" src="./ehealth_logo.png" alt="eHealth logo" width="27.5%"/>
</p>

<br/><br/><br/><br/>

**Implemented By:** Taylor Petrychyn, Paul Hewitt, Danish Junaid, Brandon Eagan, Bryce Drew, Maksym Zabutnyy

# Functional Requirements

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**

  - [1 Introduction](#1-introduction)
    - [1.1 Purpose](#11-purpose)
    - [1.2 Scope](#12-scope)
    - [1.3 References](#13-references)
    - [1.4 Assumptions](#14-assumptions)
  - [2 Methodology](#2-methodology)
  - [3 Functional Requirements](#3-functional-requirements)
      - [Table 1: Creating/Editing Ideas](#table-1-creatingediting-ideas)
      - [Table 2: Viewing Ideas](#table-2-viewing-ideas)
      - [Table 3: Searching/Filtering Ideas](#table-3-searchingfiltering-ideas)
      - [Table 4: Viewing Statistics of Ideas](#table-4-viewing-statistics-of-ideas)
      - [Table 5: Home Page/Login/Contact Us](#table-5-home-pagelogincontact-us)
      - [Table 6: PDEA Management](#table-6-pdea-management)
      - [Table 7: Administrator Tools](#table-7-administrator-tools)
      - [Table 8: User Account](#table-8-user-account)
  - [4 Other Requirements](#4-other-requirements)
    - [4.1 Interface Requirements](#41-interface-requirements)
      - [4.1.1 Software Interfaces](#411-software-interfaces)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## 1 Introduction
The system requested by eHealth with the goal to improve the quality of healthcare across the province. This follows the organization's ongoing efforts to foster an internal culture of innovation. Using Plan, Do, Evaluate, Adapt (PDEA) cycles the goal is to improve quality, cost, delivery, safety, and engagement (QCDSE).

The proposed project accomplishes this by providing an application for employees to submit their ideas for improving existing organizational processes.  This increases visibility of individual and collaborative work.

**Notice:** PDCA (**P**lan **D**o **C**heck **A**ct) has been substituted by PDEA (**P**lan **D**o **E**valuate **A**dopt). See [Discussion](./discussions.md) document.

### 1.1 Purpose
The below sections are intended to provide a list of specific functional requirements that have been integrated into minimum viable product 1.

### 1.2 USM 
The vision:
	Create the login, registration, create and view idea table functionality.
	Tie everything together with clean navigation.
	A minimalistic landing page.

Updates:
	Cards that reflect work in creating key functionality.
	Added cards for CRUD.
  
Rationale: 
  At the core, eIDEAS should be able to do our four main functions. Everything following MVP 1 will build on top and expand functionality.   Our small MVP will be less susceptible to inconsistencies and is a strong foundation for the rest of the project. 

Time Management:
  Brainstorming and idea development came before coding. Decisions about data schema and lo-fi layout changes identified early. Breaking     up roles and coding requirements to make sure that all bases are covered without overlap. 

### 1.3 References
Refer to [UR Courses](https://urcourses.uregina.ca)  project requirement documentation.

Also refer to the [Discussion Document](./discussions.md).

### 1.4 Assumptions
 * The project will be under MIT license.
 * Balsamiq is used to creating mockup screens.
 * Source code and related documents will be hosted on a public [GitHub](https://github.com/tpetrychyn/braintrust).

## 2 Methodology
Using Balsamiq, mockups for the envisioned project were created. Each mockup screen helps to identify a piece of the functionality for the whole project.

**TL;DR**
Take mockups and break them down into individual requirements (1 sentence each), then put them into a table.

## 3 Functional Requirements

#### Table 1: Creating/Editing Ideas
| ID     | Requirement Definition     |
| :--- | :--- |
| FR1-1 | The system shall allow the user to create a new idea.   |
| FR1-1.1 | When creating a new idea the system shall require the user to enter a title, problem description, and solution plan.   |
| FR1-1.2 | When creating a new idea the system shall require  the user (where applicable) to select a division and/or unit via an autocomplete drop down list.   |

#### Table 2: Viewing Ideas
| ID     | Requirement Definition     |
| :--- | :--- |
| FR2-1 | The system shall allow the user to view their own (as well as others) ideas.   |
| FR2-1.1 | Each idea shall display (at minimum) the following information: ~~idea score~~ submitter name, team, idea title, idea description, ~~"tags"/affecting areas~~, idea creation time, ~~PDEA status.~~   |

#### Table 3: Home Page/Login/Contact Us
| ID     | Requirement Definition     |
| :--- | :--- |
| FR5-1 | The system shall allow the user to log into their eIDEAS account.   |
| FR5-1.1 | The system shall allow the user to create an eIDEAS account.   |
| FR5-1.2 | The system shall allow the user to authenticate with their eIDEAS username and password.   |
| FR5-1.3 | The system shall display a "forgot password" link closely in proximity to the login button.   |
| FR5-1.3.1 | The system shall take the user to a forgot password page after clicking the "forgot password" link.   |
| FR5-2 | The system shall have a home page presented after logging in.   |
| FR5-2.1 | The system's home page shall have a ~~tabular~~ navigation bar.   |
| FR5-2.4 | The system shall have a "Contact Us" page link in the tabular navigation.   |
| FR5-2.4.1 | The "Contact Us" page shall display name, email, message field, and a submit button.   |

## 4 Other Requirements
The application should be "user-friendly" and easy to maintain.

### 4.1 Interface Requirements
The interface should be web based and mobile device friendly.

#### 4.1.1 Software Interfaces
Some kind of web stack (e.g. LAMP), using Vue.js.
