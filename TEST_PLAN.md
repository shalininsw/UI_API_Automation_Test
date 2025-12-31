# Test Plan - E-Commerce Automation Test Suite

## 1. Test Plan Overview

**Project:** E-Commerce Website Test Automation Framework  
**Application Under Test:** https://www.automationexercise.com/  
**Test Framework:** C# + Selenium WebDriver + MSTest + RestSharp  
**Test Types:** UI Automation & API Automation  
**Execution Environment:** Chrome, Edge browsers (Mac/Windows)  
**Version:** 1.0

---

## 2. Objectives

- Validate critical user journeys on the e-commerce website
- Ensure API endpoints return correct data and status codes
- Verify data integrity between UI and API layers
- Enable continuous regression testing through automation
- Support parallel test execution for faster feedback

---

## 3. Scope

### In Scope
- User authentication (Login)
- User registration and account deletion
- Product search functionality
- API endpoint testing (Product listing, Account creation)
- Cross-browser testing (Chrome, Edge)

### Out of Scope
- Payment processing
- Order management
- Mobile responsive testing (future enhancement)
- Performance testing
- Security testing

---

## 4. Test Strategy

### 4.1 UI Test Approach
- **Pattern:** Page Object Model (POM)
- **Browser Support:** Chrome (default), Edge
- **Wait Strategy:** Explicit waits with WebDriverWait
- **Parallel Execution:** Configurable through MSTestSettings

### 4.2 API Test Approach
- **Pattern:** Service Object Model
- **HTTP Client:** RestSharp
- **Validation:** Status code, response schema, response data
- **Schema Validation:** JSON schema validation using Newtonsoft.Json.Schema

---

## 5. Test Environment

| Component | Details |
|-----------|---------|
| OS | macOS, Windows |
| Browsers | Chrome (latest), Edge (latest) |
| .NET Version | 9.0 |
| Test Runner | MSTest |
| CI/CD | Not configured (future enhancement) |
| Test Data | JSON files, hardcoded test data |

---

## 6. Test Cases

### 6.1 UI Test Cases

#### TC-UI-001: Verify Login Functionality
**Test Category:** UI  
**Priority:** High  
**Preconditions:** Valid user credentials exist  

**Test Steps:**
1. Navigate to https://www.automationexercise.com/
2. Click on "Login" link
3. Enter valid email: "automationtestuser1@test.com"
4. Enter valid password
5. Click "Login" button

**Expected Result:**
- User is successfully logged in
- Username "automationtestuser1" is displayed in header
- "Logged in as" text is visible

**Test File:** `src/Ui.Tests/Tests/LoginTest.cs`  
**Test Method:** `VerifyLoginFunctionality()`

---

#### TC-UI-002: Verify Product Search Functionality
**Test Category:** UI  
**Priority:** High  
**Preconditions:** None

**Test Steps:**
1. Navigate to https://www.automationexercise.com/
2. Click on "Products" navigation link
3. Enter search keyword "jeans" in search box
4. Click search button
5. Verify search results

**Expected Result:**
- "SEARCHED PRODUCTS" title is displayed
- All displayed products contain "jeans" in their name/description
- Search results are relevant to the keyword

**Test File:** `src/Ui.Tests/Tests/ProductsTest.cs`  
**Test Method:** `VerifySearchProductsFunctionality()`

---

#### TC-UI-003: Verify Sign Up and Account Deletion
**Test Category:** UI  
**Priority:** High  
**Preconditions:** None

**Test Steps:**
1. Navigate to https://www.automationexercise.com/
2. Click on "Signup / Login" link
3. Enter random name and email
4. Click "Signup" button
5. Fill registration form with required details
6. Submit form
7. Verify account creation message
8. Verify logged in username
9. Click "Delete Account" link
10. Verify account deletion message

**Expected Result:**
- "ACCOUNT CREATED!" message is displayed
- User is logged in with registered username
- "ACCOUNT DELETED!" message is displayed after deletion

**Test File:** `src/Ui.Tests/Tests/SignUpTest.cs`  
**Test Method:** `VerifySignUpAndDeleteFunctionality()`

---

### 6.2 API Test Cases

#### TC-API-001: Verify Get Products List Returns 200
**Test Category:** API  
**Priority:** High  
**Preconditions:** API endpoint is accessible

**Test Steps:**
1. Send GET request to `/api/productsList`
2. Verify response status code
3. Verify response contains products array
4. Verify products have required fields (id, name, price, brand, category)

**Expected Result:**
- HTTP Status Code: 200
- Response contains responseCode: 200
- Products array is not empty
- Each product has valid structure

**Test File:** `src/Api.Tests/Tests/GetProductsApiTest.cs`  
**Test Method:** `GetProducts_ShouldReturn200()`

---

#### TC-API-002: Verify Get Products JSON Schema Validation
**Test Category:** API  
**Priority:** Medium  
**Preconditions:** API endpoint is accessible, Schema file exists

**Test Steps:**
1. Send GET request to `/api/productsList`
2. Load expected JSON schema from file
3. Validate response against schema

**Expected Result:**
- Response JSON structure matches defined schema
- All required fields are present
- Data types match schema definition

**Test File:** `src/Api.Tests/Tests/GetProductsApiTest.cs`  
**Test Method:** `GetProducts_SchemaValidation()`

---

#### TC-API-003: Verify Create Account Returns 201
**Test Category:** API  
**Priority:** High  
**Preconditions:** Valid user data is available

**Test Steps:**
1. Load test data from CreateAccountReq.json
2. Generate unique name and email
3. Send POST request to `/api/createAccount` with form data
4. Verify response status and message

**Expected Result:**
- HTTP Status Code: 200
- Response contains responseCode: 201
- Response message: "User created!"

**Test File:** `src/Api.Tests/Tests/CreateAccountApiTest.cs`  
**Test Method:** `CreateProduct_ShouldReturn201()`

---

## 7. Test Data Management

### 7.1 UI Test Data
- **Login Credentials:** Hardcoded in UiActionHelper
  - Email: automationtestuser1@test.com
  - Password: (configured in code)
- **Search Keywords:** Parameterized in test methods
- **Registration Data:** Randomly generated using GUID

### 7.2 API Test Data
- **Product Request:** `src/Api.Tests/Data/ApiRequests/CreateAccountReq.json`
- **JSON Schema:** `src/Api.Tests/Data/ApiSchema/` (for validation)
- **Configuration:** `src/Api.Tests/Config/AppSetting.json`

---

## 8. Entry and Exit Criteria

### Entry Criteria
- Test environment is accessible
- Application is deployed and stable
- Test data is prepared
- Required browsers are installed
- .NET 9 SDK is installed

### Exit Criteria
- All high-priority test cases executed
- 100% of critical path tests pass
- No critical/blocker defects open
- Test execution report generated

---

## 9. Test Execution

### Running All Tests
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Running UI Tests Only
```bash
dotnet test --filter "TestCategory=ui" --logger "console;verbosity=detailed"
```

### Running API Tests Only
```bash
dotnet test --filter "TestCategory=api" --logger "console;verbosity=detailed"
```

### Browser-Specific Execution
```bash
# Chrome
dotnet test --filter "TestCategory=ui" -- "TestRunParameters.Parameter(name=\"Browser\", value=\"chrome\")"

# Edge
dotnet test --filter "TestCategory=ui" -- "TestRunParameters.Parameter(name=\"Browser\", value=\"edge\")"
```
---

## 10. Risks and Mitigation

| Risk | Impact | Mitigation |
|------|--------|------------|
| Website downtime | High | Implement retry logic, monitor site availability |
| UI element changes | High | Use stable locators, implement POM for easy maintenance |
| Browser compatibility | Low | Test on multiple browsers, use WebDriverManager |

---

## 11. Future Enhancements

- Integrate HTML reporting (Extent/Allure)
- CI/CD pipeline integration (GitHub Actions/Jenkins)
- Appium integration for mobile testing
