# QSB Linear Encoder Reader

This is a simple Windows application that reads an encoder count through [US Digital QSB-D](https://www.usdigital.com/products/accessories/interfaces/usb/qsb/) and shows it in GUI.

<p>
<img src="images/screenshot.png" width="318" height="197"> 
<img src="images/qsb_d.jpeg" width="200" height="222">
</p>

## Insallation

Go to our [Releases](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/releases) page and download the zip file of the latest version named QSBLinearEncoderReader_w_x_y_z.zip where w_x_y_z is the version number (e.g. QSBLinearEncoderReader_1_4_2_0.zip).

<img src="images/download_the_latest_version.png" width="342" height="211">

Once you downloaded the zip file, right click it in the Explorer and select `Properties`. In the Properties dialog, open `General` tab and check if you can see "Unblock" checkbox in the bottom. If so, check the box and press `Apply` button. Now the checkbox should be gone. Once you confirm that the checkbox disappears, click `OK` button and extract this zip file as usual.

<p float="left">
  <img src="images/blocked_zip_file.png" width="182 height="255" />
  <img src="images/unblock_checked.png" width="182 height="255" />
  <img src="images/unblocked_zip_file.png" width="182 height="255" />
</p>
  
Once extracted, run `setup.exe` and follow the instructions to complete the installation.

<img src="images/publish_directory.png" width="426" height="206" />

If the installation is successful, the application launches automatically. Just close it at this moment.

Note: this application uses [ClickOnce](https://learn.microsoft.com/en-us/visualstudio/deployment/clickonce-security-and-deployment) technology, so the application is installed per user and you do not need administrative permission.

## Usage

### Prerequisite

Before launching this application, make sure that you connected [QSB-D](https://www.usdigital.com/products/accessories/interfaces/usb/qsb/) to an USB port of your computer.
Then, check the port name of the QSB-D with [US Digital Device Explorer](https://www.usdigital.com/support/resources/downloads/software/qsb-software/).
Typically, it is "COMx" where "x" is an integer number (e.g. COM4).

### Launch Application

Select `TMT International Observatory` - `QSB Linear Encoder Reader` in the Windows menu.

<img src="images/windows_menu.png" width="158" height="308">

### Application usage

Once the main application window is shown, click `Connect to QSB Encoder Reader`.

<img src="images/init_screen.png" width="318" height="197">

In the "Connect to QSB Encoder Reader" dialog, select an appropriate port name in `COM Port:`, set other configuration items accordingly and press the `Connect` button.

<img src="images/connect_dialog.png">

If it is connected to your QSB-D successfully, it starts to continuously read the current position from the encoder and display it in the main window as shown below:

<img src="images/screenshot.png" width="318" height="197">

Press `Zero Encoder Count` button to set the current position as zero.

You can stop recording by pressing `Stop recording` button.

## Recording to a CSV file

If you want to store the encoder readings in a CSV file, click `Set CSV Output Path...` first.
It will ask you which CSV file to save.

Then, click `Start Recording` button to start recording the encoder readings in the specified CSV file.
The CSV file has three fields "Timestamp [ms]", "Raw Count" and "Position [mm]".

This application records the encoder position at the QSB-D's maximum rate (512 Hz).
One line in the CSV file is typically 30 - 50 bytes meaning that the CSV file grows at a rate of about 15 - 25 kB/s, or 0.9 - 1.5 MB per minute.
If you leave it running for more than one day, it would use up around 100 GB of your storage.
So, please make sure that click `Stop Recording` button if you no longer need to record the encoder reading in the CSV file.

Note that the timestamp is based on the 32-bit timestamp register in the QSB-D, which is incremented at 512 Hz.
If you keep running this application more than 94.5 days, the timestamp register may be reset to 0.
The timestamp register is most probably based on a free running counter in the QSB-D, so, when you want to correlate the recorded data in the CSV file with something else, please keep in mind that it can be slightly less or more than 512 Hz.

## Upgrading

Since [version 1.4.1.0](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/releases/tag/v1.4.1.0), the application automatically checks if a new version is available every time it launches. It is recommended to follow the instruction and upgrade to the latest version.

Note: if you are using version 1.4.0.0 or older, the automatic version check feature is not available. If you want to upgrade to a newer version, you first need to [uninstall](#uninstall) the old version and install a new one.

Note: if you want to downgrade to an old version, the recommended approach is to [uninstall](#uninstall) the existing version and install the old version.

## Uninstall

TODO: fill out here

## License

TMT International Observatory holds the copyright of software, images and documents in this repository except the files below:

 * [docs/qsb-applications-examples.pdf](docs/qsb-applications-examples.pdf)
 * [docs/qsb-commands-list.pdf](docs/qsb-commands-list.pdf)

## Developer information

This chapter includes information for software developers who want to modify the code and release new versions.

### Development environment

The programming language of this software is C#. It is hightly recommended to use
Visual Studio 2022 (or newer) for software development. Instructions below assume
that you have Visual Studio installed in your computer.

### Open the latest source code with Visual Studio

If you already have Visual Studio installed in your computer, you can check out and open
the latest source code from this GitHub page. Before doing so, make sure that you are logged
in GitHub with your account. Then, click "Code" in the top right corner of this page and
select "Open with Visual Studio". Then, Visual Studio will automatically launch, check out
this git repository and open the latest source code in it.

![](images/open_with_visual_studio.png)

### Release procedure

When you release a new version, follow the steps below:

#### 1. Change assembly version number

Double-click and open [AssemblyInfo.cs](QSBLinearEncoderReader/Properties/AssemblyInfo.cs) under `Properties` in the Solution Exprlorer.
Change the version number in `AssemblyVersion` and `AssemblyFileVersion` at the bottom.

![](images/change_assembly_version.png)

### 2. Generate installer

Double-click and open `Properties` in the Solution Explorer, and select `Publish` in the left panel of the Properties pane.
Then, change the publish version to match what you set in [AssemblyInfo.cs](QSBLinearEncoderReader/Properties/AssemblyInfo.cs).
After that, press `Publish Now` button to generate an installer.

![](images/publish_pane.png)

### 3. Zip the installer

The installer is generated under `publish` folder in the project folder ([QSBlinearEncoderReader/](QSBLinearEncoderReader/)).
Copy all fikes and directorie under the `publish` directory to somewhere else. From here on, we assume that they are copied to `C:\publish`.

![](images/copy_installer_to_temporary_directory.png)

You should be able to see directories of old versions in `C:\publish\Application Files` like `QSBLinearEncoderReader_1_1_0_0`. Remove all directories of old versions and leave the latest version only.
For example, if you are going to release version w.x.y.z, remove all directories except `C:\publish\Application Files\QSBLinearEncoderReader_w_x_y_z`.

![](images/installer_for_old_versions.png)

![](images/installer_of_latest_version.png)

Then, zip all files in `C:\publish`. Make sure that `setup.exe` and `QSBLinearEncoderReader.application` are included.
Finally, change the zip file name to `QSBLinearEncoderReader_w.x.y.z.zip` where `w.x.y.z` is the version number.

### 4. Commit and push code to GitHub

At this point, commit all your local changes in your local git repository. Please make sure that your commit includes all changes and new files under the `publish` directory.
Typically, [QSBLinearEncoderReader\publish\QSBLinearEncoderReader.application](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/blob/master/QSBLinearEncoderReader/publish/QSBLinearEncoderReader.application) is updated and a new directory [publish\Application Files\QSBLinearEncoderReader_w_x_y_z](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/tree/master/QSBLinearEncoderReader/publish/Application%20Files) is added.
The commit message should indicate that it is the new release version like "Version w.x.y.z".
Then, push your local changes to the `master` branch on https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader.git.
It is recommended to confirm that your last commit appears in https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader.git before going to the next step.

Note: Contents under the [QSBLinearEncoderReader\publish](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/blob/master/QSBLinearEncoderReader/publish/) directory in the `master` branch are referenced by the automatic application updater through raw.githubusercontent.com (e.g. https://raw.githubusercontent.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/master/QSBLinearEncoderReader/publish/QSBLinearEncoderReader.application). If you want to see this automatic application updater settings, double-click and open `Properties` in the Solution Explorer, select `Publish` in the left panel of the Properties pane and press `Updates...` button. You should be able to see `Application Updates` dialog as shown below.

![](images/application_updates_setting.png)

### 5. Draft a new release

Go to [Releases](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/releases) page of this repository, and click `Draft a new release`.

![](images/github_releases_page.png)

### 6. Create a release tag on Git

In the new release page, click `Choose a tag` and enter a new git tag name for this release.
The tag name must be `vw.x.y.z` where `w.x.y.z` is the version number. Don't forget `v` at the beginning.

![](images/new_tag.png)

### 7. Enter the release information

Enter the release title and the release description. The title should be "Version w.x.y.z" where `w.x.y.z` is the actual version number.
The release description should include the summary of changes from the previous version.

Then, drag and drop the zip file you created (i.e. `QSBLinearEncoderReader_w.x.y.z.zip`) to the bottom of the page and then press `Publish release` button.

![](images/new_release_on_github.png)

### 8. Done!

Now your new released version must appear in https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader.git.

![](images/released_version_on_github.png)

Since version 1.4.1.0, every time the application launches, it investigates [QSBLinearEncoderReader/publish/QSBLinearEncoderReader.application in the `master` branch](https://raw.githubusercontent.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/master/QSBLinearEncoderReader/publish/QSBLinearEncoderReader.application) and see if there is a new version. If so, the user is suggested to upgrade to a new version and new versions are downloaded and installed automatically.

## Application examples and comamnd list of QSB-D

Application examples and command list can be obtained at 
https://www.usdigital.com/products/accessories/interfaces/usb/qsb/

The copy of those files can be found in this repository for our records:
 * [docs/qsb-applications-examples.pdf](docs/qsb-applications-examples.pdf)
 * [docs/qsb-commands-list.pdf](docs/qsb-commands-list.pdf)

## Issues

File any bugs, enhancement proposals, feature requests on [Issues](https://github.com/tmtsoftware/m1cs-qsb-linear-encoder-reader/issues).
