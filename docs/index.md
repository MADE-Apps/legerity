---
uid: front-page
title: Legerity UI Test Framework
_layout: landing
---

<div class="landing-hero">
  <img src="images/ProjectBanner.png" alt="Legerity" />
  <h1>Build maintainable UI tests quickly for Windows, Android, iOS, and Web apps</h1>
  <p>A .NET UI test framework built on Selenium and Appium with element wrappers, page objects, and fluent locators that make automated testing fast and resilient.</p>
  <div class="landing-actions">
    <a href="articles/get-started/overview.md" class="btn-primary-landing">Get started</a>
    <a href="https://github.com/MADE-Apps/legerity" class="btn-outline-landing">View on GitHub</a>
  </div>
</div>

<div class="quick-install">
  <code id="package-typewriter">dotnet add package <span id="typewriter-target">Legerity</span><span class="typewriter-cursor">|</span></code>
</div>

<div class="feature-grid">
  <div class="feature-card">
    <h3>Element wrappers</h3>
    <p>Typed wrappers for native platform controls that expose rich interaction APIs like <code>SetText()</code>, <code>SelectItem()</code>, and <code>SetValue()</code>.</p>
  </div>
  <div class="feature-card">
    <h3>Page objects</h3>
    <p>A <code>BasePage</code> abstraction with trait-based validation for building maintainable, reusable page models.</p>
  </div>
  <div class="feature-card">
    <h3>Fluent locators</h3>
    <p>Compose element queries with readable chaining like <code>By.TagName("button").WithText("Submit")</code>.</p>
  </div>
  <div class="feature-card">
    <h3>Cross-platform</h3>
    <p>Test Windows, Android, iOS, and Web apps. Run the same test suite across platforms with a single codebase.</p>
  </div>
  <div class="feature-card">
    <h3>Framework agnostic</h3>
    <p>Works with NUnit, xUnit, MSTest, or any .NET test framework. Legerity provides the infrastructure, you choose the runner.</p>
  </div>
  <div class="feature-card">
    <h3>Parallel safe</h3>
    <p>Thread-safe driver lifecycle with <code>AsyncLocal&lt;WebDriver&gt;</code> for isolated parallel test execution out of the box.</p>
  </div>
</div>

<div class="landing-cta">
  <h2>Open source and ready to use</h2>
  <div class="landing-actions">
    <a href="https://github.com/sponsors/jamesmcroft/" class="btn-outline-landing">Sponsor</a>
    <a href="https://github.com/MADE-Apps/legerity/" class="btn-outline-landing">Contribute</a>
  </div>
</div>

<script src="public/typewriter.js"></script>
