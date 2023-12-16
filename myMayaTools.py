import maya.cmds as cmds
import random

class MayaToolsWindow:
    def __init__(self):
        # Define the window name
        self.window_name = "mayaToolsWindow"

        # Create the main window
        self.create_main_window()

    def clear_existing_windows(self):
        # Delete the main window if it exists
        if cmds.window(self.window_name, exists=True):
            cmds.deleteUI(self.window_name, window=True)

        # Delete the randomization window if it exists
        if cmds.window("RandomizationOptionsWindow", exists=True):
            cmds.deleteUI("RandomizationOptionsWindow", window=True)

        # Delete the color options window if it exists
        if cmds.window("ColorOptionsWindow", exists=True):
            cmds.deleteUI("ColorOptionsWindow", window=True)

    def create_main_window(self):
        # Clear existing windows
        self.clear_existing_windows()

        # Create the main window
        self.window = cmds.window(self.window_name, title="Maya Tools Window", widthHeight=(250, 150))

        # Create a layout for the buttons
        self.layout = cmds.columnLayout(adjustableColumn=True)

        # Create buttons
        self.random_objects_button = cmds.button(label="Random Objects", command=self.show_randomization_window)
        self.change_outline_color_button = cmds.button(label="Change Wireframe Color", command=self.show_color_options_window)

        # Add a horizontal line below the main window's buttons
        cmds.separator(style="in", height=10)

        # Add text below the horizontal line
        cmds.text(label="Note: Later, I plan on adding functions for older code we made in class.\nLike the spiral staircase, calculator, or some other ideas I have.", align="left", wordWrap=True)

        # Show the window
        cmds.showWindow(self.window)

    def show_randomization_window(self, *args):
        # Clear existing windows
        self.clear_existing_windows()

        # Create a new window for randomization options
        randomize_window = cmds.window("RandomizationOptionsWindow", title="Randomization Options", widthHeight=(250, 250))
        cmds.columnLayout(adjustableColumn=True)

        # Add text message above input fields
        cmds.text(label="Give the area of the zone for where you want objects randomly generated", align="left", wordWrap=True)

        # Add a horizontal line
        cmds.separator(style="in", height=10)

        # Sliders for X, Y, Z, and number of copies
        x_slider = cmds.floatSliderGrp(field=True, minValue=0, maxValue=50, value=1, label="X")
        y_slider = cmds.floatSliderGrp(field=True, minValue=0, maxValue=50, value=1, label="Y")
        z_slider = cmds.floatSliderGrp(field=True, minValue=0, maxValue=50, value=1, label="Z")
        copies_slider = cmds.intSliderGrp(field=True, minValue=1, maxValue=100, value=2, label="Number of Copies")

        # Randomize button with callback to random_objects function
        cmds.button(label="Randomize", command=lambda *args: self.random_objects(x_slider, y_slider, z_slider, copies_slider))

        # Add a button to go back to the main window
        cmds.button(label="Back to Main Window", command=lambda *args: self.create_main_window())

        # Show the randomization window
        cmds.showWindow(randomize_window)

    def random_objects(self, x_slider, y_slider, z_slider, copies_slider, *args):
        # Query currently selected objects
        selected_objects = cmds.ls(selection=True)
        if not selected_objects:
            cmds.warning("Please select at least one object.")
            return

        # Get values from sliders
        x_value = cmds.floatSliderGrp(x_slider, query=True, value=True)
        y_value = cmds.floatSliderGrp(y_slider, query=True, value=True)
        z_value = cmds.floatSliderGrp(z_slider, query=True, value=True)
        copies_value = cmds.intSliderGrp(copies_slider, query=True, value=True)

        # Create a group to contain the randomized objects
        random_group = cmds.group(empty=True, name="randomField")

        # Generate random duplicates of selected objects in the scene with random translations
        for obj in selected_objects:
            for _ in range(copies_value):
                duplicate = cmds.duplicate(obj)[0]
                random_translation = [random.uniform(-x_value, x_value),
                                       random.uniform(-y_value, y_value),
                                       random.uniform(-z_value, z_value)]
                cmds.move(random_translation[0], random_translation[1], random_translation[2], duplicate)

                # Parent the duplicated object to the random group
                cmds.parent(duplicate, random_group)

    def show_color_options_window(self, *args):
        # Clear existing windows
        self.clear_existing_windows()

        # Create a new window for color options
        color_options_window = cmds.window("ColorOptionsWindow", title="Wireframe Color Options", widthHeight=(300, 150))

        # ... (rest of the code remains unchanged)

    def change_outline_color(self, selected_objects, color, *args):
        # Change the wireframe color of the selected objects' shape nodes directly
        if selected_objects:
            for obj in selected_objects:
                shapes = cmds.listRelatives(obj, shapes=True, fullPath=True) or []
                for shape in shapes:
                    # Set the overrideColorRGB attribute on the shape node
                    cmds.setAttr(shape + ".overrideColorRGB", *color)
        else:
            cmds.warning("No selected objects.")

# Create an instance of the MayaToolsWindow class
maya_tools_window_instance = MayaToolsWindow()
