# IP2Email :email:

![GitHub all releases](https://img.shields.io/github/downloads/oz-zo/IP2Email/total?color=%230f80c0&style=for-the-badge)
![GitHub Repo stars](https://img.shields.io/github/stars/oz-zo/IP2Email?style=for-the-badge)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/oz-zo/IP2Email/Build?style=for-the-badge)
![GitHub](https://img.shields.io/github/license/oz-zo/IP2Email?style=for-the-badge)

IP2Email sends an email with your public IP address got by <https://ifconfig.me>

## Screenshots

<div>
<details>
  <summary>Screenshots</summary>
  <img src="https://github.com/oz-zo/scrn/raw/main/screenshots/ip2email-view.png" alt="Show IP screen">
  <img src="https://github.com/oz-zo/scrn/raw/main/screenshots/ip2email-config.png" alt="Configuration screen">
  <img src="https://github.com/oz-zo/scrn/raw/main/screenshots/ip2email-send.png" alt="Email send screen">
  <img src="https://github.com/oz-zo/scrn/raw/main/screenshots/ip2email-help.png" alt="Help screen">
</details>
</div>

## Usage options

Usage: IP2Email [-config] | [-send]

* Configure and temporary save email recipient & sender settings option

```shell
-config
```

* Send your public IP address within configured email settings option

```shell
-send
```

#### WARNING: DO NOT ENTER YOUR CURRENT EMAIL'S LOGIN AND PASSWORD! IT'S NOT SAFE! 
#### CREATE NEW EMAIL ACCOUNT WITH A STRONG AND RANDOM PASSWORD.

## Return codes:

- 0 All actions completed successfully.
- 10 An exception occurred while getting the local IP address.
- 20 An exception occurred while getting the external IP address.
- 30 An exception occurred while saving email settings.
- 40 No details for email sending provided.
- 50 An exception occurred while sending email.
