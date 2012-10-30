class CreateVideoSubtitles < ActiveRecord::Migration
  def change
    create_table :video_subtitles do |t|

      t.timestamps
    end
  end
end
