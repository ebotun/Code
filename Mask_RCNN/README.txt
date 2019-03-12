Default values are set to simplify the use of the parser.

To training with the provided vehicle dataset in the datasets folder use:
Example: python vehicle.py train

With other pretrained weights (Coco can also used) use:
Example: python vehicle.py train --weights /path/to/specific/weights.h5

For prediction (with the given weights), put the image inside of the img_for_testing folder and use the command:
Example: python vehicle.py splash

Selecting another folder for prediction can be done as follows:
python vehicle.py splash --imagedir /path/to/folder/

Other weights can be used for prediction (Example is COCO, but download is required, approximate 500MB):
python vehicle.py splash --weights /path/to/weights.h5

The results are placed inside of img_vid_results directory.

Using prediciton on a video:
python vehicle.py splash --video /path/to/specific/video.avi

PS: python terminal and powershell are used used to execute the commands/args.

PS: Adjust the path to the folder if any problems are met upon regarding file not found.





