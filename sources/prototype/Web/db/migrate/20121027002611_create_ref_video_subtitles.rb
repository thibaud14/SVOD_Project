class CreateRefVideoSubtitles < ActiveRecord::Migration
  def change
    create_table :ref_video_subtitles do |t|
      t.string :name

      t.timestamps
    end
  end
end
